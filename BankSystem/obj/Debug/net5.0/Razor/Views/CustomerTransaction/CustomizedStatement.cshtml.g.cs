#pragma checksum "C:\Users\rphri\OneDrive\Desktop\BankSystem\BankSystem\Views\CustomerTransaction\CustomizedStatement.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f21327d5bbf2a8236c86007803b5ef37d7b7e12e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_CustomerTransaction_CustomizedStatement), @"mvc.1.0.view", @"/Views/CustomerTransaction/CustomizedStatement.cshtml")]
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
#line 1 "C:\Users\rphri\OneDrive\Desktop\BankSystem\BankSystem\Views\_ViewImports.cshtml"
using BankSystem;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\rphri\OneDrive\Desktop\BankSystem\BankSystem\Views\_ViewImports.cshtml"
using BankSystem.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f21327d5bbf2a8236c86007803b5ef37d7b7e12e", @"/Views/CustomerTransaction/CustomizedStatement.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ba398e21c14d25c174079e6de44b03ba2cc6a271", @"/Views/_ViewImports.cshtml")]
    public class Views_CustomerTransaction_CustomizedStatement : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<BankSystem.Models.TransactionViewModel>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("text-danger"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "CustomizedStatement", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "CustomerTransaction", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.ValidationSummaryTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationSummaryTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n\r\n\r\n");
#nullable restore
#line 5 "C:\Users\rphri\OneDrive\Desktop\BankSystem\BankSystem\Views\CustomerTransaction\CustomizedStatement.cshtml"
  
    ViewData["Title"] = "CustomizedStatement";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n<div class=\" row ml-2\">\r\n    <h5>Bank Statement</h5>\r\n</div>\r\n<hr />\r\n");
#nullable restore
#line 14 "C:\Users\rphri\OneDrive\Desktop\BankSystem\BankSystem\Views\CustomerTransaction\CustomizedStatement.cshtml"
 if (@ViewBag.istrue)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"alert alert-danger\" role=\"alert\">\r\n        ");
#nullable restore
#line 17 "C:\Users\rphri\OneDrive\Desktop\BankSystem\BankSystem\Views\CustomerTransaction\CustomizedStatement.cshtml"
   Write(ViewBag.errorMessage);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </div>\r\n");
#nullable restore
#line 19 "C:\Users\rphri\OneDrive\Desktop\BankSystem\BankSystem\Views\CustomerTransaction\CustomizedStatement.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("<hr />\r\n");
#nullable restore
#line 21 "C:\Users\rphri\OneDrive\Desktop\BankSystem\BankSystem\Views\CustomerTransaction\CustomizedStatement.cshtml"
 if (Model == null)
{
    

#line default
#line hidden
#nullable disable
            WriteLiteral("    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f21327d5bbf2a8236c86007803b5ef37d7b7e12e5968", async() => {
                WriteLiteral("\r\n        ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("div", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f21327d5bbf2a8236c86007803b5ef37d7b7e12e6234", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationSummaryTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.ValidationSummaryTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_ValidationSummaryTagHelper);
#nullable restore
#line 26 "C:\Users\rphri\OneDrive\Desktop\BankSystem\BankSystem\Views\CustomerTransaction\CustomizedStatement.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_ValidationSummaryTagHelper.ValidationSummary = global::Microsoft.AspNetCore.Mvc.Rendering.ValidationSummary.ModelOnly;

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-validation-summary", __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationSummaryTagHelper.ValidationSummary, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral(@"
        <div class=""form-group"">

            <div class=""form-group"">
                <label class=""control-label"">Account No</label>
                <input class=""form-control"" name=""accountNo"" />
                <span class=""text-danger""></span>
            </div>
            <div class=""form-group"">
                <label class=""control-label"" >From Date</label>
                <input class=""form-control "" type=""datetime"" name=""fromDate"" id=""datetimepicker1""/>
                <span class=""text-danger""></span>
            </div>
            <div class=""form-group"">
                <label class=""control-label"">To Date</label>
                <input class=""form-control"" type=""datetime"" name=""toDate"" />
                <span class=""text-danger""></span>
            </div>

            <div class=""form-group"">
                <input type=""submit"" value=""View"" class=""btn btn-secondary"" />
            </div>
            </div>
    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 50 "C:\Users\rphri\OneDrive\Desktop\BankSystem\BankSystem\Views\CustomerTransaction\CustomizedStatement.cshtml"

}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n\r\n\r\n");
#nullable restore
#line 56 "C:\Users\rphri\OneDrive\Desktop\BankSystem\BankSystem\Views\CustomerTransaction\CustomizedStatement.cshtml"
 if (Model != null)

{


#line default
#line hidden
#nullable disable
            WriteLiteral(@"    <div class=""container"">
        <div class=""row"">
            <div class=""col-12 cart_dt"">
                <table class=""table table-bordered table-sm"">
                    <thead>
                        <tr class=""bg-secondary"">
                            <th scope=""col"">TransactionId</th>
                            <th scope=""col"">From AccountNo</th>
                            <th scope=""col"">To AccountNo</th>
                            <th scope=""col"">Transaction Date</th>
                            <th scope=""col"">Transaction Amount</th>
                            <th scope=""col"">Debit</th>
                            <th scope=""col"">Credit</th>
                            <th scope=""col"">Balance</th>
                            <th scope=""col"">Description</th>
                        </tr>

                    </thead>
                    <tbody>
                        <tr>
");
#nullable restore
#line 80 "C:\Users\rphri\OneDrive\Desktop\BankSystem\BankSystem\Views\CustomerTransaction\CustomizedStatement.cshtml"
                             foreach (var item in Model)
                            {


#line default
#line hidden
#nullable disable
            WriteLiteral("                        <tr>\r\n                            <td>");
#nullable restore
#line 84 "C:\Users\rphri\OneDrive\Desktop\BankSystem\BankSystem\Views\CustomerTransaction\CustomizedStatement.cshtml"
                           Write(item.TransactionId);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td>");
#nullable restore
#line 85 "C:\Users\rphri\OneDrive\Desktop\BankSystem\BankSystem\Views\CustomerTransaction\CustomizedStatement.cshtml"
                           Write(item.FromAccountNo);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td>");
#nullable restore
#line 86 "C:\Users\rphri\OneDrive\Desktop\BankSystem\BankSystem\Views\CustomerTransaction\CustomizedStatement.cshtml"
                           Write(item.ToAccountNo);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td>");
#nullable restore
#line 87 "C:\Users\rphri\OneDrive\Desktop\BankSystem\BankSystem\Views\CustomerTransaction\CustomizedStatement.cshtml"
                           Write(item.TransactionDate);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td>");
#nullable restore
#line 88 "C:\Users\rphri\OneDrive\Desktop\BankSystem\BankSystem\Views\CustomerTransaction\CustomizedStatement.cshtml"
                           Write(item.TransactionAmount);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n");
#nullable restore
#line 89 "C:\Users\rphri\OneDrive\Desktop\BankSystem\BankSystem\Views\CustomerTransaction\CustomizedStatement.cshtml"
                             if (item.TransactionType == "Debit")
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <td>");
#nullable restore
#line 91 "C:\Users\rphri\OneDrive\Desktop\BankSystem\BankSystem\Views\CustomerTransaction\CustomizedStatement.cshtml"
                               Write(item.TransactionType);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                <td>   </td>\r\n                                <td>");
#nullable restore
#line 93 "C:\Users\rphri\OneDrive\Desktop\BankSystem\BankSystem\Views\CustomerTransaction\CustomizedStatement.cshtml"
                               Write(item.FromAccountBalance);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n");
#nullable restore
#line 94 "C:\Users\rphri\OneDrive\Desktop\BankSystem\BankSystem\Views\CustomerTransaction\CustomizedStatement.cshtml"

                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 97 "C:\Users\rphri\OneDrive\Desktop\BankSystem\BankSystem\Views\CustomerTransaction\CustomizedStatement.cshtml"
                             if (item.TransactionType == "Credit")
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <td> </td>\r\n                                <td>");
#nullable restore
#line 100 "C:\Users\rphri\OneDrive\Desktop\BankSystem\BankSystem\Views\CustomerTransaction\CustomizedStatement.cshtml"
                               Write(item.TransactionType);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n");
            WriteLiteral("                                <td>");
#nullable restore
#line 102 "C:\Users\rphri\OneDrive\Desktop\BankSystem\BankSystem\Views\CustomerTransaction\CustomizedStatement.cshtml"
                               Write(item.ToAccountBalance);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n");
#nullable restore
#line 103 "C:\Users\rphri\OneDrive\Desktop\BankSystem\BankSystem\Views\CustomerTransaction\CustomizedStatement.cshtml"
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            <td>");
#nullable restore
#line 105 "C:\Users\rphri\OneDrive\Desktop\BankSystem\BankSystem\Views\CustomerTransaction\CustomizedStatement.cshtml"
                           Write(item.Description);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        </tr>\r\n");
#nullable restore
#line 107 "C:\Users\rphri\OneDrive\Desktop\BankSystem\BankSystem\Views\CustomerTransaction\CustomizedStatement.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                            </tr>\r\n                        </tbody>\r\n                    </table>\r\n                </div>\r\n            </div>\r\n        </div>\r\n");
#nullable restore
#line 114 "C:\Users\rphri\OneDrive\Desktop\BankSystem\BankSystem\Views\CustomerTransaction\CustomizedStatement.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            DefineSection("scripts", async() => {
                WriteLiteral(@"
   <script>

       $(document).ready(function () {
           $('#datetimepicker1').datepicker({
               format: ""dd/mm/yyyy"",
               language: ""es"",
               autoclose: true,
               todayHighlight: true
           };
          
       })
       </script>

");
            }
            );
            WriteLiteral("\r\n\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<BankSystem.Models.TransactionViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591