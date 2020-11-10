
var AddOrEdit = "Edit";
var ID;

function CreateTable() {
    $.ajax({
        url: "http://localhost:44329/api/Store/",
        type: "Get",
        dataType: "json",
        success: function (data) {
            CreateTableRows(data["Data"]);
        }
    })
}

function CreateTableRows(data) {
    $("#StoreTable").find("tr:not(:first)").remove();
    var i = 0;
    for (i = 0; i < data.length; i++) {
        var $line = $('<tr>');
        var $NO = $('<td style="text-align: center">');
        $NO.html(data[i]["Code"]);

        var $Name = $('<td>');
        $Name.html(data[i]["Name"]);

        var $Operato = $('<td>');

        var $EidtButton = $('<button data-toggle="modal" data-target="#myModal"></button>');
        $EidtButton.html("修改");
        $EidtButton.on("click", data[i], RowChickEdit);

        var $RmButton = $('<button>');
        $RmButton.html("删除");
        $RmButton.on("click", data[i], RowChickRemove);

        $Operato.append($EidtButton);
        $Operato.append($RmButton);

        $line.append($NO);
        $line.append($Name);
        $line.append($Operato);
        $("#StoreTable").append($line);
    }
}

function RowChickEdit(data) {
    $("#StoreName").val(data.data.Name);
    $("#StoreAddress").val(data.data.Address);
    $("#StoreManager").val(data.data.Manager);
    $("#StoreWarehouse").val(data.data.WarehouseCode);
    AddOrEdit = "Edit";
    ID = data.data.Code+"";
}

function RowChickRemove(data) {
    $.ajax({
        url: "/StoreManager/DeleteStore",
        data: {
            Code: data.data.Code
        },
        type: "POST",
        dataType: "json",
        success: function (data) {
            if (data["isSeccess"]) {
                CreateTable();
            }
        }
    })
}

function RowChickAdd() {
    $("#StoreName").val("");
    $("#StoreAddress").val("");
    $("#StoreManager").val("");
    $("#StoreWarehouse").val("");
    AddOrEdit = "Add";
    ID = "-1";
}


function CommitForm() {
    $.ajax({
        url: "/StoreManager/AddOrEditStore",
        data: {
            Code:ID,
            Name: $("#StoreName").val(),
            Address: $("#StoreAddress").val(),
            Manager: $("#StoreManager").val(),
            WarehouseCode: $("#StoreWarehouse").val()
        },
        type: "POST",
        dataType: "json",
        success: function (data) {
            if (data["isSeccess"]) {
                CreateTable();
            }
        }
    })

}

function SearchContent() {
    $.ajax({
        url: "/StoreManager/GetStoreByName",
        data: {
            name : $("#Search_Box").val()
        },
        type: "POST",
        dataType: "json",
        success: function (data) {
            CreateTableRows(data["Data"]);
        }
    })

}

window.onload = function () {
    CreateTable();
    $("#AddButton").bind('click', this.RowChickAdd);
    $("#CommitButton").bind('click', this.CommitForm);
    $("#SearchButton").bind('click', this.SearchContent);
}
