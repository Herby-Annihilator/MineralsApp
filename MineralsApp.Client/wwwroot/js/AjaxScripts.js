$(document).on('click', "#createMineralBtn", function (e) {
    e.preventDefault();

    var jsonObject = JSON.stringify({
        "id": 0,
        "mineralName": $("#mineralName").val(),
        "description": $("#description").val(),
        "searchers": $("#searchers").val(),
        "publish": $("#publish").val(),
        "field": $("#field").val(),
        "territory": $("#territory").val(),
        "pathToImage": "some/path/to/some/image"
    });

    $.ajax({
        type: "POST",
        url: "create/",
        dataType: "json",
        contentType: "application/json",
        accepts: "application/json",
        data: jsonObject,
        success: function () {
            console.log(jsonObject);
        }
    }).done(function (response) {
        $("#mineralsTable").append(`<tr>
                            <td>${response.mineralName}</td>
                            <td>
                                <img src="~/images/mineral_2.png" width="170" height="100" alt="">
                            </td>
                            <td>Опубликовано</td>
                            <td>19.02.2022</td>
                            <td>
                                <button class="btn_view">
                                    <a href="Minerals/details/${response.id}">
                                    </a>
                                </button>
                                <button class="btn_edit">
                                    <a href="Minerals/edit/${response.id}">
                                    </a>
                                </button>
                                <button class="btn_delete" id="${response.id}">
                                </button>
                            </td>
                          </tr>`
        );
    });
});

$(document).on('click', '.readMore', function (e) {
    e.preventDefault();
    var id = $(this).attr("id");
    $("#mineralDescription").load("MineralDescription/" + id, function (response) {
        if (response.length > 0)
            $("#describeMineral").modal('show');
    });
});

$(document).on('click', '.btn_delete', function () {
    var id = $(this).attr("id");
    $.ajax({
        type: 'GET',
        url: "delete/" + id
    });
});
