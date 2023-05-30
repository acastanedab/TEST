using System.Web;
using System.Web.Optimization;

namespace Yanbal.SFT.Presentation.Web
{
    /// <summary>
    /// Clase que representa la Configuración de Bundle
    /// </summary>
    /// <remarks>
    /// Creación:       GMD 20140922 <br />
    /// Modificación:                <br />
    /// </remarks>
    public class BundleConfig
    {
        /// <summary>
        /// Constructor por Defecto de implementación de la clase
        /// </summary>
        protected BundleConfig()
        {
        }

        /// <summary>
        /// Clase Estatica que Registra bundles
        /// </summary>
        /// <param name="bundles">Colección de bundles</param>
        public static void RegisterBundles(BundleCollection bundles)
        {
            /*JQUERY*/
            bundles.Add(new ScriptBundle("~/bundles/JQuery").Include(
                        "~/Scripts/JQuery/jquery-{version}.js",
                        "~/Scripts/JQuery/jquery.event.drag-2.2.js",
                        "~/Scripts/JQuery/jshashset-3.0.js",
                        "~/Scripts/JQuery/jshashtable-3.0.js",
                        "~/Scripts/JQuery/jquery.numberformatter-1.2.4.js",
                        "~/Scripts/JQuery/jquery.formatCurrency-1.4.0.js",
                        "~/Scripts/JQuery/jquery.mask.js"
                        ));

            bundles.Add(new ScriptBundle("~/bundles/JQueryui").Include(
                        "~/Scripts/JQuery/jquery-ui-1.10.4.custom.js"
                        ));

            bundles.Add(new ScriptBundle("~/bundles/JQueryval").Include(
                //"~/Scripts/Common/jquery.unobtrusive*", ,new CssRewriteUrlTransform()
                        "~/Scripts/JQuery/jquery.validate*"));

            /*JQuery Resources*/
            bundles.Add(new ScriptBundle("~/JQuery/Resources").Include(
               "~/Scripts/JQuery/Resources/jquery.ui.datepicker-es-pe.js",
               "~/Scripts/JQuery/Resources/jquery.ui.datepicker-pt-br.js"
               ));


            bundles.Add(new StyleBundle("~/JQuery/css").Include(
                "~/Scripts/JQuery/jquery-ui-1.10.4.custom.css"

                ));

            /*TIMEPICKER*/
            bundles.Add(new ScriptBundle("~/bundles/TimePicker").Include(
                         "~/Scripts/JQuery/jquery.ui.timepicker.js"));

            bundles.Add(new StyleBundle("~/TimePicker/css").Include(
                "~/Scripts/JQuery/jquery.ui.timepicker.css"
                ));

            /*COLORPICKER*/
            bundles.Add(new ScriptBundle("~/bundles/ColorPicker").Include(
                         "~/Scripts/JQuery/jquery.colorpicker.js",
                         "~/Scripts/JQuery/jquery.ui.colorpicker-cmyk-parser.js",
                         "~/Scripts/JQuery/jquery.ui.colorpicker-cmyk-percentage-parser.js",
                         "~/Scripts/JQuery/jquery.ui.colorpicker-memory.js",
                         "~/Scripts/JQuery/jquery.ui.colorpicker-rgbslider.js"
                         ));

            bundles.Add(new StyleBundle("~/ColorPicker/css").Include(
                "~/Scripts/JQuery/jquery.colorpicker.css"
                ));
            /*COLORPICKER Resources*/
            bundles.Add(new ScriptBundle("~/ColorPicker/Resources").Include(
               "~/Scripts/JQuery/Resources/jquery.ui.colorpicker-de.js",
               "~/Scripts/JQuery/Resources/jquery.ui.colorpicker-en.js",
               "~/Scripts/JQuery/Resources/jquery.ui.colorpicker-fr.js",
               "~/Scripts/JQuery/Resources/jquery.ui.colorpicker-nl.js",
               "~/Scripts/JQuery/Resources/jquery.ui.colorpicker-pt-br.js"
               ));

            /*Knockout*/
            bundles.Add(new ScriptBundle("~/bundles/Knockout").Include(
            "~/Scripts/Knockout/knockout-2.1.0.js"));

            /*Bootstrap*/
            bundles.Add(new ScriptBundle("~/bundles/Bootstrap").Include(
                        "~/Scripts/JQuery/bootstrap.js",
                        "~/Scripts/JQuery/bootstrap-datepicker.js"
                        ));

            bundles.Add(new StyleBundle("~/Bootstrap/css").Include(
                "~/Scripts/Bootstrap/bootstrap.css",
                "~/Scripts/Bootstrap/datepicker.css"
                ));

            bundles.Add(new StyleBundle("~/Font-awesome/css").Include(
                "~/Scripts/Font-awesome/font-awesome.css"
                ));
                        
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            /*Componentes Personalizados*/
            bundles.Add(new StyleBundle("~/Components/css").Include(
              "~/Scripts/Components/ProgressBar/ProgressBar.css",
              "~/Scripts/Components/Dialog/Dialog.css",
              "~/Scripts/Components/Message/Message.css",
              "~/Scripts/Components/Grid/Grid.css"
              ));

            bundles.Add(new ScriptBundle("~/bundles/Components").Include(
                        "~/Scripts/Codemaleon/ns.js",
                        "~/Scripts/Components/ProgressBar/ProgressBar.js",
                        "~/Scripts/Components/AjaxUtil/AjaxUtil.js",
                        "~/Scripts/Components/Validator/Validator.js",
                        "~/Scripts/Components/Dialog/Dialog.js",
                        "~/Scripts/Components/Calendar/Calendar.js",
                        "~/Scripts/Components/Message/Message.js",
                        "~/Scripts/Components/TextBox/TextBox.js",
                        "~/Scripts/Base/Master.js",
                        "~/Scripts/Components/Grid/Grid.js",
                        "~/Scripts/Components/Grid/SlickGrid/firebugx.js",
                        "~/Scripts/Components/Grid/SlickGrid/slick.*"
                        ));

            /*Theme Site*/
            bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/Content/animate.css",
                "~/Content/Main.css",
                "~/Content/Dev.css"));
        }
    }
}