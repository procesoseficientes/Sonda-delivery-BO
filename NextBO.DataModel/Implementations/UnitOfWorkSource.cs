using DevExpress.Mvvm;
using DevExpress.Mvvm.DataModel;
using DevExpress.Mvvm.DataModel.DesignTime;
using DevExpress.Mvvm.DataModel.EFCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using NextApi.DataAccessLayer;
using System;
using System.IO;

namespace NextBO.DataModel
{

    /// <summary>
    /// Provides methods to obtain the relevant IUnitOfWorkFactory.
    /// </summary>
    public static class UnitOfWorkSource
    {

        /// <summary>
        /// Returns the IUnitOfWorkFactory implementation based on the current mode (run-time or design-time).
        /// </summary>
        public static IUnitOfWorkFactory<INextBOUnitOfWork> GetUnitOfWorkFactory()
        {
            return GetUnitOfWorkFactory(ViewModelBase.IsInDesignMode);
        }

        /// <summary>
        /// Returns the IUnitOfWorkFactory implementation based on the given mode (run-time or design-time).
        /// </summary>
        /// <param name="isInDesignTime">Used to determine which implementation of IUnitOfWorkFactory should be returned.</param>
        public static IUnitOfWorkFactory<INextBOUnitOfWork> GetUnitOfWorkFactory(bool isInDesignTime)
        {

            var builder = new ConfigurationBuilder()
       .SetBasePath(Directory.GetCurrentDirectory())
       .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            IConfiguration conf = builder.Build();
            
            var connectionString = conf.GetConnectionString("NextDatabase") ?? Environment.GetEnvironmentVariable("NextDatabase");
            //   Configuration.GetConnectionString("NextDatabase");
            var optionsBuilder = new DbContextOptionsBuilder<NextDatabaseContext>();
            optionsBuilder.UseLazyLoadingProxies().UseSqlServer(connectionString);

            if (isInDesignTime)
                return new DesignTimeUnitOfWorkFactory<INextBOUnitOfWork>(() => new DesignTimeDevDbUnitOfWork());
            Func<NextApi.DataAccessLayer.NextDatabaseContext> contextFactory =
                () => new NextDatabaseContext(optionsBuilder.Options);

            return new DbUnitOfWorkFactory<INextBOUnitOfWork>(() => new DbUnitOfWork(contextFactory));
        }
    }
}