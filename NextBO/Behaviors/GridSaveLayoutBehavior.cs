using DevExpress.Mvvm;
using DevExpress.Mvvm.UI.Interactivity;
using DevExpress.Xpf.Grid;
using DevExpress.Xpf.LayoutControl;
using System.IO;
using System.Xml;

namespace NextBO.Wpf
{
    public class GridSaveLayoutBehavior : Behavior<GridControl>
    {
        public string FileName { get; set; }

        protected bool IsRestoreAccessible = false;

        #region SaveLayoutCommand

        protected DelegateCommand _SaveLayoutCommand;

        public DelegateCommand SaveLayoutCommand
        {
            get
            {
                if (this._SaveLayoutCommand == null)
                {
                    this._SaveLayoutCommand = new DelegateCommand(this.SaveCommandExecute, this.SaveCommandCanExecute);
                }

                return this._SaveLayoutCommand;
            }
        }

        protected void SaveCommandExecute()
        {
            this.AssociatedObject.SaveLayoutToXml(this.FileName);
            this.IsRestoreAccessible = true;
        }

        protected bool SaveCommandCanExecute()
        {
            bool result = true;
            return result;
        }

        #endregion SaveLayoutCommand

        #region RestoreCommand

        protected DelegateCommand _RestoreLayoutCommand;

        public DelegateCommand RestoreLayoutCommand
        {
            get
            {
                if (this._RestoreLayoutCommand == null)
                {
                    this._RestoreLayoutCommand = new DelegateCommand(this.RestoreCommandExecute, this.RestoreCommandCanExecute);
                }

                return this._RestoreLayoutCommand;
            }
        }

        protected void RestoreCommandExecute()
        {
            this.AssociatedObject.RestoreLayoutFromXml(this.AssociatedObject.View.Name + "_Default.xml");
        }

        protected bool RestoreCommandCanExecute()
        {
            bool result = File.Exists(this.AssociatedObject.View.Name + "_Default.xml");
            return result;
        }

        #endregion RestoreCommand

        protected override void OnAttached()
        {
            base.OnAttached();
        }

        protected override void OnChanged()
        {
            base.OnChanged();
        }
    }

    public class LayoutControlSaveBehavior : Behavior<LayoutControl>
    {
        public string FileName { get; set; }

        protected bool IsRestoreAccessible = false;

        #region SaveLayoutCommand

        protected DelegateCommand _SaveLayoutCommand;

        public DelegateCommand SaveLayoutCommand
        {
            get
            {
                if (this._SaveLayoutCommand == null)
                {
                    this._SaveLayoutCommand = new DelegateCommand(this.SaveCommandExecute, this.SaveCommandCanExecute);
                }

                return this._SaveLayoutCommand;
            }
        }

        protected void SaveCommandExecute()
        {
            XmlWriter writer = XmlWriter.Create(this.FileName + ".xml");
            this.AssociatedObject.WriteToXML(writer);
            this.IsRestoreAccessible = true;
            writer.Close();
        }

        protected bool SaveCommandCanExecute()
        {
            bool result = true;
            return result;
        }

        #endregion SaveLayoutCommand

        #region RestoreCommand

        protected DelegateCommand _RestoreLayoutCommand;

        public DelegateCommand RestoreLayoutCommand
        {
            get
            {
                if (this._RestoreLayoutCommand == null)
                {
                    this._RestoreLayoutCommand = new DelegateCommand(this.RestoreCommandExecute, this.RestoreCommandCanExecute);
                }

                return this._RestoreLayoutCommand;
            }
        }

        protected void RestoreCommandExecute()
        {
            XmlReader reader = XmlReader.Create(this.FileName + "_Default.xml");
            this.AssociatedObject.ReadFromXML(reader);
            reader.Close();
        }

        protected bool RestoreCommandCanExecute()
        {
            bool result = File.Exists(this.FileName + "_Default.xml");
            return result;
        }

        #endregion RestoreCommand

        protected override void OnAttached()
        {
            base.OnAttached();
        }

        protected override void OnChanged()
        {
            base.OnChanged();
        }
    }
}
