using AutoInventory.App_Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AutoInventory
{
    public partial class InventoryData : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String data = Automobile.GetListing();
            String script = @"
    var app = angular.module('autoInventory', ['ngTable']).

    controller('AutomobileController', function ($scope, $filter, NgTableParams) {
        data=" + data + @";

            $scope.tableParams = new NgTableParams({
                page: 1,            // show first page
                count: 10,          // count per page
                sorting: {
                    name: 'asc'     // initial sorting
                }
            }, {
                total: data.length, // length of data
                getData: function($defer, params) {
                    // use build-in angular filter
                    var orderedData = params.sorting() ?
                                        $filter('orderBy')(data, params.orderBy()) :
                                        data;

                    $defer.resolve(orderedData.slice((params.page() - 1) * params.count(), params.page() * params.count()));
                }
            });
        })";

            Response.ClearHeaders();
            Response.ClearContent();
            Response.ContentType = "text/plain";
            Response.Output.Write(script);
        }
    }
}