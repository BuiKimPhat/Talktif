#pragma checksum "D:\PBL3\Talktif\Views\User\Home.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5a9738e404a13b9a912dd127d3233c472e582d11"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_User_Home), @"mvc.1.0.view", @"/Views/User/Home.cshtml")]
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
#line 1 "D:\PBL3\Talktif\Views\User\Home.cshtml"
using Program.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5a9738e404a13b9a912dd127d3233c472e582d11", @"/Views/User/Home.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4621befad1af1cb1036aa1d9a27168b6ec5f1e0d", @"/Views/_ViewImports.cshtml")]
    public class Views_User_Home : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<User_Infor>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "All", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "HN", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "TPHCM", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "DN", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "D:\PBL3\Talktif\Views\User\Home.cshtml"
  
    Layout = "~/Views/Shared/_UserLayoutPage.cshtml";
    ViewData["Name"] = (Model != null)?Model.name:"";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<div class=""row"">
            <div class=""col-lg-4 col-md-4 col-sm-4 col-xs-4 mt-4"">
                <div class=""dropdown col-lg-6 col-md-6 col-xs-6 col-sm-6 pr-0 pl-0 float-right"">
                    <div class=""theme"">
                        <button class=""theme-transform light"" onClick={LightTheme}>
                          <a class=""active-type"" href=""# "">
                            <img src=""/img/sunny.png""");
            BeginWriteAttribute("alt", " alt=\"", 584, "\"", 590, 0);
            EndWriteAttribute();
            WriteLiteral(@" />
                          </a>
                        </button>
                        <button class=""theme-transform dark"" onClick={DarkTheme}>
                          <a class=""active-type"" href=""# "">
                            <img src=""/img/moon.png""");
            BeginWriteAttribute("alt", " alt=\"", 859, "\"", 865, 0);
            EndWriteAttribute();
            WriteLiteral(@" />
                          </a>
                        </button>
                    </div>
                    <div class=""mt-5 text-center effect"">
                        <div class=""row"">
                            <div class=""col-lg-9 col-md-9 col-sm-9 col-xs-9"">
                                <p class=""float-left"">Hiệu ứng <button type=""button"" class=""btn p-0"" style=""height:24px;outline:none;""><i class=""fas fa-chevron-down""></i></p></button>
                            </div>
                            <div class=""col-lg-3 col-md-3 col-sm-3 col-xs-3 float-right"">
                                <button class=""btn""><span><i class=""fas fa-times-circle""></i></span></button>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class=""col-lg-4 col-md-4 col-sm-4 col-xs-4 mt-4"">
                <div class=""row"">
                    <div class=""col-lg-12 col-md-12 col-sm-12 col-xs-12 d-fle");
            WriteLiteral("x align-items-center justify-content-between\">\r\n                        <button class=\"btn mr-1 type-actor\">\r\n                            <img src=\"../img/friendship.png\"");
            BeginWriteAttribute("alt", " alt=\"", 2060, "\"", 2066, 0);
            EndWriteAttribute();
            BeginWriteAttribute("srcset", " srcset=\"", 2067, "\"", 2076, 0);
            EndWriteAttribute();
            WriteLiteral(">\r\n                             Cả hai\r\n                        </button>\r\n                        <button class=\"btn mr-1 type-actor\">\r\n                            <img src=\"../img/boy.png\"");
            BeginWriteAttribute("alt", " alt=\"", 2267, "\"", 2273, 0);
            EndWriteAttribute();
            BeginWriteAttribute("srcset", " srcset=\"", 2274, "\"", 2283, 0);
            EndWriteAttribute();
            WriteLiteral(">\r\n                             Nam\r\n                        </button>\r\n                        <button class=\"btn mr-1 type-actor \">\r\n                            <img src=\"../img/girl.png\"");
            BeginWriteAttribute("alt", " alt=\"", 2473, "\"", 2479, 0);
            EndWriteAttribute();
            BeginWriteAttribute("srcset", " srcset=\"", 2480, "\"", 2489, 0);
            EndWriteAttribute();
            WriteLiteral(@">
                             Nữ
                        </button>
                    </div>
                </div>
                <div class=""row main_chat"">
                    <div class=""col-lg-6 col-md-6 col-sm-6 col-xs-6"">
                        <div class=""box"">
                        </div>
                    </div>
                    <div class=""col-lg-6 col-md-6 col-sm-6 col-xs-6"">
                        <div class=""box text-center d-flex justify-content-center flex-column align-items-center"">
                            <h5 class=""Text-Meeting d-block mb-5"">Gặp gỡ bạn bè </br>mới nào</h5>
                            <div class=""img-couple""><img class=""rounded-circle"" src=""../img/couple.png""");
            BeginWriteAttribute("alt", " alt=\"", 3221, "\"", 3227, 0);
            EndWriteAttribute();
            BeginWriteAttribute("srcset", " srcset=\"", 3228, "\"", 3237, 0);
            EndWriteAttribute();
            WriteLiteral("></div>\r\n                        </div>\r\n                        <div class=\"group-btn-interactive d-flex justify-content-between align-items-center mt-2\">\r\n                            <button class=\"interactive\"><img src=\"../img/add-user.png\"");
            BeginWriteAttribute("alt", " alt=\"", 3481, "\"", 3487, 0);
            EndWriteAttribute();
            BeginWriteAttribute("srcset", " srcset=\"", 3488, "\"", 3497, 0);
            EndWriteAttribute();
            WriteLiteral("></button>\r\n                            <button class=\"interactive\"><img src=\"../img/like.png\"");
            BeginWriteAttribute("alt", " alt=\"", 3592, "\"", 3598, 0);
            EndWriteAttribute();
            BeginWriteAttribute("srcset", " srcset=\"", 3599, "\"", 3608, 0);
            EndWriteAttribute();
            WriteLiteral(@"></button>
                        </div>
                    </div>
                </div>
                <div class=""col-lg-12 col-sm-12 col-md-12 col-xs-12 d-flex justify-content-center mt-3"">
                    <button class=""btn-next-person d-flex justify-content-center align-items-center""><p class=""text mr-2 mb-0"">Bắt đầu</p><img class=""icon_next"" src=""../img/right-arrow.png""");
            BeginWriteAttribute("alt", " alt=\"", 4000, "\"", 4006, 0);
            EndWriteAttribute();
            BeginWriteAttribute("srcset", " srcset=\"", 4007, "\"", 4016, 0);
            EndWriteAttribute();
            WriteLiteral(@"></button>
                </div>
            </div>
            <div class=""col-lg-4 col-md-4 col-sm-4 col-xs-4 mt-4"">
                <div class=""row d-flex justify-content-center align-items-center"">
                    <div class=""col-lg-9 col-md-9 col-sm-9 col-xs-9 select"">
                        <select name=""format"" id=""format"" defaultValue=""All"">
                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5a9738e404a13b9a912dd127d3233c472e582d1110659", async() => {
                WriteLiteral("All");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5a9738e404a13b9a912dd127d3233c472e582d1111840", async() => {
                WriteLiteral("HN");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5a9738e404a13b9a912dd127d3233c472e582d1113020", async() => {
                WriteLiteral("TPHCM");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5a9738e404a13b9a912dd127d3233c472e582d1114203", async() => {
                WriteLiteral("DN");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
                      </select>
                    </div>
                </div>
                <div class=""row"">
                    <div class=""col-lg-9 col-md-9 col-sm-9 col-xs-9"">
                        <div class=""box message-box"">
                            <div class=""message-box-content"">
                            </div>
                            <div class=""message-box-action"">
                                <div>
                                    <input type=""text"" id=""message"" class=""message"" placeholder=""Nhập tin nhắn và nhấn Enter"" />
                                </div>
                                <button class=""send_message""><img src=""../img/send_mes.png""");
            BeginWriteAttribute("alt", " alt=\"", 5325, "\"", 5331, 0);
            EndWriteAttribute();
            BeginWriteAttribute("srcset", " srcset=\"", 5332, "\"", 5341, 0);
            EndWriteAttribute();
            WriteLiteral("></button>\r\n                            </div>\r\n                        </div>\r\n                    </div>\r\n\r\n                </div>\r\n            </div>");
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
