using DevExpress.Mvvm.UI;
using Newtonsoft.Json;
using NextApi.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace NextBO.Wpf
{
    public interface IRouteOptimizerService
    {
        Task<MatrixApi> OptimizeRoute(string cordSource, string cordDestination);
        Task<List<RouteSimulatorDetail>> ObtenerDistancia(List<RouteSimulatorDetail> ListRouteDetail, string originLongitude, string originLatitude);
    }

    public class RouteOptimizerService : ServiceBase, IRouteOptimizerService
    {
        /// <summary>
        /// Optimize route between two waypoints
        /// </summary>
        public async Task<MatrixApi> OptimizeRoute(string cordSource, string cordDestination)
        {
            try
            {
                string url = "";
                string coordSource = "-90.5399691,14.6511030";
                string coordDestination = "-90.541672,14.650405999999975";

                url = $"https://api.mapbox.com/optimized-trips/v1/mapbox/driving/{ cordSource };{ cordDestination }?source=first&destination=last&access_token=pk.eyJ1IjoicGFibG9hZ3VpbGFyIiwiYSI6ImNrMG56dWV6eDA1ajIzbHBrd25qdXk0dzkifQ.DrXcPY3yCREDbhuTMg2B5A";

                HttpClient urlMapBoxRequest = new HttpClient();
                urlMapBoxRequest.DefaultRequestHeaders.Accept.Clear();
                urlMapBoxRequest.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                using (HttpResponseMessage response = await urlMapBoxRequest.GetAsync(url))
                {
                    if (response.IsSuccessStatusCode)
                    {

                        string responseApi = await response.Content.ReadAsStringAsync();
                        var result = JsonConvert.DeserializeObject<MatrixApi>(responseApi);

                        return result;
                    }
                    else
                    {
                        throw new Exception(response.ReasonPhrase);
                    }
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// Get distance between waypoints
        /// </summary>
        public async Task<List<RouteSimulatorDetail>> ObtenerDistancia(List<RouteSimulatorDetail> ListRouteDetail, string originLongitude, string originLatitude)
        {
            //DECLARAMOS LAS VARIABLES, EN UNA DE ELLA CONTENDREMOS LA COORDENADA
            //List<RouteSimulatorDetail> ListRouteDetail = new List<RouteSimulatorDetail>();
            if (ListRouteDetail.Count <= 0) return ListRouteDetail;

            MatrixApi ResultOptimizerRoute = new MatrixApi();
            decimal distanceMin = 0;
            string cordInit = ",";
            string cordEnd = "";
            var numeroDeParada = 0;

            //ALMACENA EL ULTIMO CLIENTE OPTIMIZADO
            RouteSimulatorDetail sourceClient = new RouteSimulatorDetail();


            //LISTA DE LOS PUNTO A RECORRER EN BASE AL PUNTO ORIGEN
            List<RouteSimulatorDetail> ListPointsPending = new List<RouteSimulatorDetail>();
            //LISTA DE LOS PUNTOS SIN ASIGNAR ORDEN
            List<RouteSimulatorDetail> ListRouteDetailWithoutAssigned = new List<RouteSimulatorDetail>();

            //VARIABLE PARA ALMACENAR LA RUTA DE ORIGEN LUEGO DE HABER SIDO ASIGNADO
            RouteSimulatorDetail detailItem = new RouteSimulatorDetail();
            //VARIABLE PARA ALMACENAR LA RUTA CON LA DISTANCIA MAS PEQUEÑA
            RouteSimulatorDetail routeMinDistance = new RouteSimulatorDetail();

            //--FILTRAMOS LOS QUE NO TENGAN UBICACION
            ListRouteDetail = ListRouteDetail.FindAll(x => x.Latitude != 0 && x.Longitude != 0);

            //RECORREMOS LA LISTA, SIN CONTAR LOS QUE NO TIENEN PUNTOS GPS
            for (var i = 0; (ListRouteDetail.Count) > i; i++)
            {

                //REALIZAMOS UNA COPIA DE LA LISTA DE PUNTOS DEL DETALLE, ESTA SERA SOBRE LA CUAL TRABAJAREMOS
                ListPointsPending = ListRouteDetail;

                detailItem = ListRouteDetail[i];

                if (i == 0)
                {
                    //SE CONSTRUYE EL STRING DE LA CORDENADA DE INICIO
                    originLatitude.Replace(",", ".");
                    originLongitude.Replace(",", ".");
                    cordInit = originLongitude + "," + originLatitude;
                }

                //SE TOMAN EN CUENTA SOLAMENTE LAS QUE NO ESTAN ASIGNADAS
                if (detailItem.isAssigned == null)
                {

                    //RECORREMOS TODOS LOS PUNTOS NUEVAMENTE PARA ENCONTRAR EL PUNTO MAS CERCANO AL ACTUAL
                    for (var d = 0; (ListPointsPending.Count - 1) >= d; d++)
                    {
                        //VARIABLE PARA ALMACENAR EL PUNTO PENDIENTE DEL CUAL SE ESTA OBTENINENDO LA DISTANCIA.
                        RouteSimulatorDetail currentRoute = new RouteSimulatorDetail();
                        currentRoute = ListPointsPending[d];

                        //RECOREMOS NUEVAMENTE TODOS LOS PUNTOS RESPECTO AL ACTUAL PARA OBTENER EL DE LA MENOR DISTANCIA Y OMITIMOS EL PROPIO GPS
                        if ((currentRoute.isAssigned == null) && (sourceClient.ClientCode != currentRoute.ClientCode && sourceClient.ManifestId != currentRoute.ManifestId && sourceClient.Order != currentRoute.Order))
                        {
                            //SE CONSTRUYE EL STRING DE LA CORDENADA DE DESTINO
                            cordEnd = currentRoute.Longitude.ToString().Replace(",", ".") + "," + currentRoute.Latitude.ToString().Replace(",", ".");

                            //OBTENEMOS EL RESULTADO DE LA OPTIMIZACION
                            ResultOptimizerRoute = await OptimizeRoute(cordInit, cordEnd);

                            //ACTUALIZAMOS EL ITEM DEL ARREGLO CON LA DISTANCIA Y EL TIEMPO QUE SE TOMARA LA RUTA DE UN PUNTO A OTRO
                            currentRoute.distance = Convert.ToDecimal(ResultOptimizerRoute.trips[0].legs[0].distance);
                            currentRoute.time = Convert.ToDecimal(ResultOptimizerRoute.trips[0].legs[0].duration);

                            System.Diagnostics.Debug.WriteLine(JsonConvert.SerializeObject(ResultOptimizerRoute));

                        }

                    }

                    //BUSCAMOS EL PUNTO MAS CERCANO AL ACTUAL

                    ListRouteDetailWithoutAssigned = ListPointsPending.FindAll(x => x.isAssigned == null);
                    distanceMin = ListRouteDetailWithoutAssigned.Min(x => x.distance).Value;
                    routeMinDistance = ListRouteDetailWithoutAssigned.Find(x => x.distance == distanceMin && x.isAssigned == null);

                    //AGREGAMOS UN ORDEN EN LAS PARADAS QUE SE DEBEN DE REALIZAR
                    numeroDeParada += 1;


                    //AGREGA EL NUEVO PUNTO DE INICIO PARA UBICAR EL PUNTO MAS CERCANO
                    cordInit = routeMinDistance.Longitude.ToString().Replace(",", ".") + "," + routeMinDistance.Latitude.ToString().Replace(",", ".");

                    detailItem.distance = routeMinDistance.distance;
                    detailItem.time = routeMinDistance.time;
                    detailItem.isAssigned = numeroDeParada;
                }

            }
            //TRAZA LA RUTA DE REGRESO A LA BODEGA CONFIGURADA
            if (ListRouteDetail.Count > 0)
            {

                var ultimoPunto = ListRouteDetail.Count;
                //CONSTRUIMOS LA CORDENADA DE DESTINO - GPS CONFIGURADO EN LOS PARAMETROS
                cordEnd = originLongitude.Replace(",", ".") + "," + originLatitude.Replace(",", ".");

                //CONSTRUIMOS LA CORDENADA DE PARTIDA - ULTIMA EN EL LISTADO
                RouteSimulatorDetail newDetail = new RouteSimulatorDetail();

                detailItem = ListRouteDetail[ultimoPunto - 1];

                //ASIGNAMOS EL CLIENTE A OPTIMIZAR
                sourceClient = detailItem;

                newDetail.Address = detailItem.Address;
                newDetail.ClientCode = detailItem.ClientCode;
                newDetail.ClientName = detailItem.ClientName;
                newDetail.distance = 0;
                newDetail.DistanceCost = 0;
                newDetail.DistanceToTravel = 0;
                newDetail.isAssigned = 0;
                newDetail.ManifestId = detailItem.ManifestId;
                newDetail.Order = detailItem.Order;
                newDetail.TotalVolume = 0;
                newDetail.TotalWeight = 0;
                newDetail.VehicleId = detailItem.VehicleId;

                cordInit = detailItem.Longitude.ToString().Replace(",", ".") + "," + detailItem.Latitude.ToString().Replace(",", ".");

                //OBTENEMOS EL RESULTADO DE LA OPTIMIZACION
                ResultOptimizerRoute = await OptimizeRoute(cordInit, cordEnd);

                //ACTUALIZAMOS EL ITEM DEL ARREGLO CON LA DISTANCIA Y EL TIEMPO QUE SE TOMARA LA RUTA DE UN PUNTO A OTRO
                newDetail.distance = Convert.ToDecimal(ResultOptimizerRoute.trips[0].legs[0].distance);
                newDetail.time = Convert.ToDecimal(ResultOptimizerRoute.trips[0].legs[0].duration);
                newDetail.Longitude = Convert.ToDecimal(originLongitude);
                newDetail.Latitude = Convert.ToDecimal(originLatitude);

                newDetail.isAssigned = ultimoPunto + 1;

                ListRouteDetail.Add(newDetail);
            }

            return ListRouteDetail;

        }

    }
}
