#pragma checksum "D:\PBL3\Talktif\Views\Admin\Home.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7f4f64dfdb1c93bffc7036b22456120effef8f45"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Admin_Home), @"mvc.1.0.view", @"/Views/Admin/Home.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "D:\PBL3\Talktif\Views\_ViewImports.cshtml"
using Program;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "D:\PBL3\Talktif\Views\Admin\Home.cshtml"
using Program.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7f4f64dfdb1c93bffc7036b22456120effef8f45", @"/Views/Admin/Home.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4621befad1af1cb1036aa1d9a27168b6ec5f1e0d", @"/Views/_ViewImports.cshtml")]
    public class Views_Admin_Home : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<User_Infor>
    {
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "D:\PBL3\Talktif\Views\Admin\Home.cshtml"
  
    Layout = null;

#line default
#line hidden
#nullable disable
            WriteLiteral("<!DOCTYPE html>\r\n<html lang=\"en\">\r\n\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "7f4f64dfdb1c93bffc7036b22456120effef8f453275", async() => {
                WriteLiteral(@"
    <meta charset=""UTF-8"" />
    <meta name=""viewport"" content=""width=device-width,initial-scale=1,maximum-scale=1"" />
    <title>Document</title>
    <link rel=""stylesheet"" href=""https://cdn.jsdelivr.net/gh/lykmapipo/themify-icons@0.1.2/css/themify-icons.css"" />
    <link rel=""stylesheet"" href=""https://cdnjs.cloudflare.com/ajax/libs/font-awesome/5.15.3/css/all.min.css"" />
    <!-- Latest compiled and minified CSS -->
    <!-- <link rel=""stylesheet"" href=""https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css"" /> -->

    <!-- jQuery library -->
    <script src=""https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js""></script>

    <!-- Popper JS -->
    <!-- <script src=""https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.16.0/umd/popper.min.js""></script> -->

    <!-- Latest compiled JavaScript -->
    <!-- <script src=""https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js""></script> -->
    <link rel=""stylesheet"" href=""../css/Admin.css"" />
");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "7f4f64dfdb1c93bffc7036b22456120effef8f455284", async() => {
                WriteLiteral(@"
    <input type=""checkbox"" id=""sidebar-toggle"" />
    <div class=""sidebar"">
        <div class=""sidebar-header"">
            <h3 class=""brand"">
                <!-- <span class=""ti-unlink""></span> -->
                <span><a href=""#""><img src=""../img/logo_main.png""");
                BeginWriteAttribute("alt", " alt=\"", 1416, "\"", 1422, 0);
                EndWriteAttribute();
                WriteLiteral(@" class=""logo"" /></a
          ></span>
                <!-- <span>TalkTif</span> -->
            </h3>
            <label for=""sidebar-toggle"" class=""ti-menu-alt""></label>
        </div>

        <div class=""sidebar-menu"">
            <ul>
                <li class=""active"">
                    <a");
                BeginWriteAttribute("href", " href=\"", 1731, "\"", 1738, 0);
                EndWriteAttribute();
                WriteLiteral(">\r\n                        <span class=\"ti-home icon\"></span>\r\n                        <span>Home</span>\r\n                    </a>\r\n                </li>\r\n                <li>\r\n                    <a");
                BeginWriteAttribute("href", " href=\"", 1938, "\"", 1945, 0);
                EndWriteAttribute();
                WriteLiteral(">\r\n                        <span class=\"ti-face-smile icon\"></span>\r\n                        <span>User</span>\r\n                    </a>\r\n                </li>\r\n                <li>\r\n                    <a");
                BeginWriteAttribute("href", " href=\"", 2151, "\"", 2158, 0);
                EndWriteAttribute();
                WriteLiteral(">\r\n                        <span class=\"ti-agenda icon\"></span>\r\n                        <span>Chat Room</span>\r\n                    </a>\r\n                </li>\r\n                <li>\r\n                    <a");
                BeginWriteAttribute("href", " href=\"", 2365, "\"", 2372, 0);
                EndWriteAttribute();
                WriteLiteral(">\r\n                        <span class=\"ti-book icon\"></span>\r\n                        <span>Contacts</span>\r\n                    </a>\r\n                </li>\r\n                <li>\r\n                    <a");
                BeginWriteAttribute("href", " href=\"", 2576, "\"", 2583, 0);
                EndWriteAttribute();
                WriteLiteral(@">
                        <span class=""ti-settings icon""></span>
                        <span>Account</span>
                    </a>
                </li>
            </ul>
        </div>
    </div>

    <div class=""main-content"">
        <header>
            <div class=""search-wrapper"">
                <span class=""ti-search""></span>
                <input type=""search"" placeholder=""Search"" />
            </div>

            <div class=""social-icons"">
                <span class=""ti-bell""></span>
                <span class=""ti-comment""></span>
                <div></div>
            </div>
        </header>

        <main>
            <h2 class=""dash-title"">Overview</h2>

            <div class=""dash-cards"">
                <div class=""card-single"">
                    <div class=""card-body"">
                        <span class=""ti-briefcase""></span>
                        <div>
                            <h5>Customer</h5>
                            <h4>30</h4>
        ");
                WriteLiteral("                </div>\r\n                    </div>\r\n                    <div class=\"card-footer\">\r\n                        <a");
                BeginWriteAttribute("href", " href=\"", 3733, "\"", 3740, 0);
                EndWriteAttribute();
                WriteLiteral(@">View all</a>
                    </div>
                </div>

                <div class=""card-single"">
                    <div class=""card-body"">
                        <span class=""ti-reload""></span>
                        <div>
                            <h5>Messages</h5>
                            <h4>30</h4>
                        </div>
                    </div>
                    <div class=""card-footer"">
                        <a");
                BeginWriteAttribute("href", " href=\"", 4207, "\"", 4214, 0);
                EndWriteAttribute();
                WriteLiteral(@">View all</a>
                    </div>
                </div>

                <div class=""card-single"">
                    <div class=""card-body"">
                        <span class=""ti-check-box""></span>
                        <div>
                            <h5>User online</h5>
                            <h4>30</h4>
                        </div>
                    </div>
                    <div class=""card-footer"">
                        <a");
                BeginWriteAttribute("href", " href=\"", 4687, "\"", 4694, 0);
                EndWriteAttribute();
                WriteLiteral(@">View all</a>
                    </div>
                </div>
            </div>

            <section class=""recent"">
                <div class=""activity-grid"">
                    <div class=""activity-card"">
                        <h3>Recent activity</h3>

                        <div class=""table-responsive"">
                            <table>
                                <thead>
                                    <tr>
                                        <th>Project</th>
                                        <th>Start Date</th>
                                        <th>End Date</th>
                                        <th>Team</th>
                                        <th>Status</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <tr>
                                        <td>App Development</td>
                                        <td>15 Aug,");
                WriteLiteral(@" 2020</td>
                                        <td>22 Aug, 2020</td>
                                        <td class=""td-team"">
                                            <div class=""img-1""></div>
                                            <div class=""img-2""></div>
                                            <div class=""img-3""></div>
                                        </td>
                                        <td>
                                            <span class=""badge success"">Success</span>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Logo Design</td>
                                        <td>15 Aug, 2020</td>
                                        <td>22 Aug, 2020</td>
                                        <td class=""td-team"">
                                            <div class=""img-1""></div>
                                        ");
                WriteLiteral(@"    <div class=""img-2""></div>
                                            <div class=""img-3""></div>
                                        </td>
                                        <td>
                                            <span class=""badge warning"">Processing</span>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Server setup</td>
                                        <td>15 Aug, 2020</td>
                                        <td>22 Aug, 2020</td>
                                        <td class=""td-team"">
                                            <div class=""img-1""></div>
                                            <div class=""img-2""></div>
                                            <div class=""img-3""></div>
                                        </td>
                                        <td>
                                            <span");
                WriteLiteral(@" class=""badge success"">Success</span>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Front-end Design</td>
                                        <td>15 Aug, 2020</td>
                                        <td>22 Aug, 2020</td>
                                        <td class=""td-team"">
                                            <div class=""img-1""></div>
                                            <div class=""img-2""></div>
                                            <div class=""img-3""></div>
                                        </td>
                                        <td>
                                            <span class=""badge warning"">Processing</span>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Web Development</td>
   ");
                WriteLiteral(@"                                     <td>15 Aug, 2020</td>
                                        <td>22 Aug, 2020</td>
                                        <td class=""td-team"">
                                            <div class=""img-1""></div>
                                            <div class=""img-2""></div>
                                            <div class=""img-3""></div>
                                        </td>
                                        <td>
                                            <span class=""badge success"">Success</span>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </div>
                    </div>

                    <div class=""summary"">
                        <div class=""summary-card"">
                            <div class=""summary-single"">
                                <span class=""ti-id-badge""></");
                WriteLiteral(@"span>
                                <div>
                                    <h5>196</h5>
                                    <small>Number of chatrooms</small>
                                </div>
                            </div>
                            <div class=""summary-single"">
                                <span class=""ti-calendar""></span>
                                <div>
                                    <h5>16</h5>
                                    <small>Number of leave</small>
                                </div>
                            </div>
                            <div class=""summary-single"">
                                <span class=""ti-face-smile""></span>
                                <div>
                                    <h5>12</h5>
                                    <small>Profile update request</small>
                                </div>
                            </div>
                        </div>

                       ");
                WriteLiteral(@" <div class=""bday-card"">
                            <div class=""bday-flex"">
                                <div class=""bday-img""></div>
                                <div class=""bday-info"">
                                    <h5>Hai Quy</h5>
                                    <small>Birthday Today</small>
                                </div>
                            </div>

                            <div class=""text-center"">
                                <button>
                    <span class=""ti-gift""></span>
                    Wish him
                  </button>
                            </div>
                        </div>
                    </div>
                </div>
            </section>
        </main>
    </div>
    <script>
        $(document).ready(function() {
            $("".sidebar li"").hover(
                function() {
                    $(this).addClass(""active"");
                },
                function() {
                    $(this)");
                WriteLiteral(".removeClass(\"active\");\r\n                }\r\n            );\r\n        });\r\n    </script>\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n</html>");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<User_Infor> Html { get; private set; }
    }
}
#pragma warning restore 1591
