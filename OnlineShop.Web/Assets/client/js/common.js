var common = {
    init: function () {
        common.registerEvents();
    },
    registerEvents: function () {
        $("#txtKeyword").autocomplete({
            minLength: 0,
            source: function (request, response) {
                $.ajax({
                    url: "/Product/GetListProductByName",
                    dataType: "json",
                    data: {
                        keyword: request.term
                    },
                    success: function (res) {
                        response(res.data);
                    }
                });
            },
            focus: function (event, ui) {
                $("#txtKeyword").val(ui.item.Name);
                return false;
            },
            select: function (event, ui) {
                $("#txtKeyword").val(ui.item.Name);
                return false;
            }
        }).autocomplete("instance")._renderItem = function (ul, item) {
            return $("<li>")
                .append("<a href=\"/tim-kiem.html?keyword=" + item.Name + "\">" + item.Name + "</a>")
                .appendTo(ul);
        };
    }
}

common.init();