using DevExpress.Mvvm.UI.Interactivity;
using DevExpress.Xpf.RichEdit;
using DevExpress.Xpf.SpellChecker;
using System.Globalization;

namespace NextBO.Wpf
{
    public class SpellCheckerRichEditBehavior : Behavior<RichEditControl>{
        SpellChecker spellChecker;
        protected override void OnAttached() {
            base.OnAttached();
            AssociatedObject.SpellChecker = spellChecker;
        }
        public SpellCheckerRichEditBehavior() {
            spellChecker = CreateSpellChecker();
        }
        SpellChecker CreateSpellChecker() {
            SpellChecker spellChecker = new SpellChecker();
            spellChecker.Culture = new CultureInfo("es-GT");
            spellChecker.SpellCheckMode = DevExpress.XtraSpellChecker.SpellCheckMode.AsYouType;
            //SpellCheckTextControllersManager.Default.RegisterClass(typeof(RichEditControl), typeof(RichEditSpellCheckController));
            return spellChecker;
        }
    }
}
