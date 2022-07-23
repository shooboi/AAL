$(document).ready(function () {

    $("#btn-import").click(() => {
        $("#in-import").trigger("click");
    });

    $("#in-import").on("change", function (e) {
        $("#handle-import").trigger("click");
    });

    $("#btnSaveItem").click(function () {
        var itemid = $("#itemIdList").val();
        var quantity = $("#itemQuantity").val();

        $("#itemIdList option[value='" + itemid + "']").each(function () {
            $(this).remove();
        })

        $("#tableContent").append("<tr class='itemCol'><th class='itemId' data-id=" + itemid + ">" + itemid + "</th><th class='itemQuantity' data-quantity=" + quantity + ">" + quantity + "</th></tr>");
    })

    $("#submitOrder").submit(function (e) {
        e.preventDefault();
        var data = {};

        var data = {};

        data.orderDate = $("#OrderDate").val();
        data.status = $("#Status").val();
        data.orderDetails = [];

        $(".itemCol").each(function () {
            var itemid = $(this).find(".itemId").data("id");
            var quantity = $(this).find(".itemQuantity").data("quantity");

            data.orderDetails.push({ itemId: itemid, quantity: quantity });
        });
        console.log(data);
        $.ajax({
            url: "/Admin/Orders/Create",
            dataType: "json",
            method: "POST",
            data: data,
            success: function (res) {
                location.href = "/Admin/Orders";
            },
            error: function (err) {

            }
        });
    });
});