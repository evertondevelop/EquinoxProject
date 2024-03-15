// This code sets up bundling and minification for the static web assets in this ASP.NET Core project.
// By default, ASP.NET Core does not bundle or minify static assets, but this configuration enables
// both processes to improve the load time and performance of the application.
//
// The `BundlerMinifier.Core` package is used to perform the bundling and minification.
// This package is included as a reference in the project and provides the necessary classes
// and methods to configure and execute the bundling and minification process.
//
// To use this configuration, place all the static web assets that should be bundled and
// minified in the `wwwroot` folder. Then, update the `bundleConfig.json` file to specify
// the files and bundles to be created.
//
// For more information on configuring bundling and minification in ASP.NET Core, see the
// official documentation at <https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification>.
