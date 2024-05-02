


///alert in adminLayout page
function appendLiveAlert(type, message) {
    const wrapper = $('<div> </div>');

    wrapper.html([
        `<div class="alert alert-${type} alert-dismissible" role="alert">`,
        `   <div>${message}</div>`,
        '   <button type="button" class="btn-close" data-bs-dismiss="alert" aria-label="Close"></button>',
        '</div>'
    ].join(''));

    $('#liveAlertPlaceholder').append(wrapper);
}
/// create list categury item
function createCateguryItemAdminPanel(result) {

    for (let i = 0; i < result.length; i++) {

        const TableRow = $("<tr> </tr>");

        TableRow.attr("data-id", result[i].categuryId);

        var status = result[i].isAvailable === true ? "فعال" : "غیر‌فعال";
        var statusBtn = status === "فعال" ? "غیر‌فعال" : "فعال";
        TableRow.html([
            `<th scope="row">${i + 1}</th>`,
            `<td>‌ <img src="/${result[i].srcCategury}" alt="${result[i].categuryName}" width="100" height="100"> </td>`,
            `<td>${result[i].categuryName}</td>`,
            `<td class="categuryStatus">${status}</td>`,
            `<td> <button type="button" class="btn activate-categury btn-danger">${statusBtn}</button> </td>`,
            `<td> <button type="button" class="btn btn-warning edit-categury">تصحیح</button> </td>`,
            `<td> <button type="button" class="btn btn-danger">حذف</button> </td>`
        ].join(''));
        $("#TbodyCateguryAdmin").append(TableRow);

        $(TableRow).on("click", "button.activate-categury", function () {

            var id = $(this).parent().parent().attr("data-id");

            const changeCateguryStatusUrl = `/api/categury/ChangeStatus?id=${id}`;

            var request = $.ajax({
                url: changeCateguryStatusUrl,
                type: "GET",
                success: function (result) {
                    if (result) {
                        GetAllCateguryAdminPanel();
                    }
                },
                error: function (xhr, status, strMessage) {
                    console.log(`status request:  ${status} , str message: ${strMessage}`);
                }

            });
            request.done(function () { });
        })

        $(TableRow).on("click", "button.edit-categury", function () {

            var id = $(this).parent().parent().attr("data-id");

            const EditCateguryUrl = `/api/categury/GetSingleCategury?id=${id}`;

            var request = $.ajax({
                url: EditCateguryUrl,
                type: "GET",
                success: function (result) {
                    if (result) {
                        //console.log(result);
                        $("#EditCateguryTitle").val(result.categuryName);
                        $("#EditCategurySubmit").attr("data-Id", result.categuryId)
                        $("#EditCateguryBtnModal").modal("show");
                    }
                },
                error: function (xhr, status, strMessage) {
                    console.log(`status request:  ${status} , str message: ${strMessage}`);
                }

            });
            request.done(function () { });
        })
    }

}
/// activate categury function 

/// list categuries on admin panel
function GetAllCateguryAdminPanel() {

    const GetAllCateguryUrl = "/api/categury/GetAllCategury";
    $("#TbodyCateguryAdmin").empty();
    var request = $.ajax({
        url: GetAllCateguryUrl,
        type: "GET",
        processData: false,
        contentType: false,
        success: function (result) {
            //console.log(result);
            createCateguryItemAdminPanel(result);
        },
        error: function (xhr, status, strMessage) {
            console.log(`status request:  ${status} , str message: ${strMessage}`);
        },
    });
    request.done(function (xhr, status, message) { })
}

function GenerateCateguryOptionItem(model, parentID, selectedCategury = null) {
    var parent = $(`#${parentID}`);
    parent.empty();

    for (let i = 0; i < model.length; i++) {
        var newOptionEelement = $("<option> </option");
        newOptionEelement.attr("value", `${model[i].categuryId}`);
        newOptionEelement.text(`${model[i].categuryName}`);
        parent.append(newOptionEelement);
    }
    $(`select#${parentID} option[value='${selectedCategury}']`).attr("selected", "selected");
}

function createProductItemAdminPanel(result) {
    for (let i = 0; i < result.length; i++) {

        const TableRow = $("<tr> </tr>");

        TableRow.attr("data-id", result[i].productId);

        var status = result[i].isActive === true ? "فعال" : "غیر‌فعال";
        var statusBtn = status === "فعال" ? "غیر‌فعال" : "فعال";
        TableRow.html([
            `<th scope="row">${i + 1}</th>`,
            `<td>‌ <img src="/${result[i].pictureSrc}" alt="${result[i].productTitle}" width="100" height="100"> </td>`,
            `<td>${result[i].productTitle}</td>`,
            `<td>${result[i].productPrice}</td>`,
            `<td>${result[i].categuryName}</td>`,
            `<td class="categuryStatus">${status}</td>`,
            `<td> <button type="button" class="btn activate-product btn-danger">${statusBtn}</button> </td>`,
            `<td> <button type="button" class="btn btn-warning edit-Product">تصحیح</button> </td>`,
            `<td> <button type="button" class="btn btn-danger">حذف</button> </td>`
        ].join(''));
        $("#TbodyProductAdmin").append(TableRow);

        $(TableRow).on("click", "button.activate-product", function () {

            var id = $(this).parent().parent().attr("data-id");

            const changeProductStatusUrl = `/api/Product/ChangeStatus?ProductId=${id}`;

            var request = $.ajax({
                url: changeProductStatusUrl,
                type: "GET",
                success: function (result) {
                    if (result) {
                        GetAllProductAdminPanel();
                    }
                },
                error: function (xhr, status, strMessage) {
                    console.log(`status request:  ${status} , str message: ${strMessage}`);
                }

            });
            request.done(function () { });
        })

        $(TableRow).on("click", "button.edit-Product", function () {

            var id = $(this).parent().parent().attr("data-id");
            GetSingleProductData(id);
        });
    }
}
function GetCateguryOption(ParentID, selectedCategury = null) {
    var request = $.ajax({
        type: "GET",
        url: "/api/Product/GetAllCateguryAddProduct",
        accepts: "application/json",
        success: function (result) {
            //console.log(result);
            if (selectedCategury === null) {
                GenerateCateguryOptionItem(result, ParentID);
            } else {
                GenerateCateguryOptionItem(result, ParentID, selectedCategury);
            }
        },
        error: function (xhr, status, Message) {
            console.log(`xhr : ${xhr}, status : ${status}, message : ${Message}`);
        }
    });
    request.done(function () { });
}
function GetSingleProductData(id) {
    const EditProductUrl = `/api/Product/GetSingleProduct?ProductId=${id}`;

    var request = $.ajax({
        url: EditProductUrl,
        type: "GET",
        success: function (result) {
            if (result) {
                GetCateguryOption("editProductSubCategury", result.categuryId);
                console.log(result);
                $("#editProductTitle").val(result.productTitle);
                $("#editProductPrice").val(result.productPrice);
                $("#editProductDescription").val(result.productDescription);
                $("#IsWithDiscountEditProduct").val(result.isWithDiscount);
                $("#editProductWithDiscount").val(result.discountAmountOption);
                if (result.isWithDiscount) {
                    $("#IsWithDiscountEditProduct").prop('checked', true);
                    $("#editProductGroupParent").css("visibility", "visible");
                }
                else {
                    $("#IsWithDiscountEditProduct").prop('checked', false);
                    $("#editProductGroupParent").css("visibility", "hidden");
                }
                $("#IsWithDiscountEditProduct").on("change", function () {
                    if (this.checked) {
                        $("#editProductGroupParent").css("visibility", "visible");
                    }
                    else {
                        $("#editProductGroupParent").css("visibility", "hidden");
                    }
                })
                $("#EditProductSubmit").attr("data-Id", result.productId);
                $("#EditProductBtnModal").modal("show");
            }
        },
        error: function (xhr, status, strMessage) {
            console.log(`status request:  ${status} , str message: ${strMessage}`);
        }

    });
    request.done(function () { });
}
function GetAllProductAdminPanel() {

    const GetAllProductUrl = "/api/Product/GetAllProductAdminPanel";
    $("#TbodyProductAdmin").empty();
    var request = $.ajax({
        url: GetAllProductUrl,
        type: "GET",
        success: function (result) {
            console.log(result);
            createProductItemAdminPanel(result);
        },
        error: function (xhr, status, strMessage) {
            console.log(`status request:  ${status} , str message: ${strMessage}`);
        },
    });
    request.done(function (xhr, status, message) { })
}

$(document).ready(function () {

    /// categury concept
    $('#addCategurySubmit').on("submit", async function (e) {
        e.preventDefault();

        const categuryUrl = "/api/categury/AddCategury";
        const ImgAddCategury = document.querySelector('#AddCateguryImage');

        var formdata = new FormData();
        formdata.append("Image", ImgAddCategury.files[0]);
        formdata.append("name", $('#addCateguryTitle').val());

        var addCateguryRequest = $.ajax({
            url: categuryUrl,
            type: "POST",
            contentType: false,
            processData: false,
            data: formdata,
            success: function (result) {

                // console.log(result);
                appendLiveAlert(result.type, result.message);

                if (result.isSuccess) {
                    setTimeout(() => {
                        GetAllCateguryAdminPanel();
                    }, 2500);
                }
            },
            error: function (xhr, status, strmessage) {
                console.log(`status request:  ${status} , str message: ${strmessage}`);
            }
        });
        addCateguryRequest.done(function () { })
    });
    $('#EditCategurySubmit').on("submit", async function (e) {
        e.preventDefault();

        var id = $('#EditCategurySubmit').attr("data-Id");
        var name = $('#EditCateguryTitle').val();
        const EditcateguryUrl = `/api/Categury/EditCategury?id=${id}&name=${name}`;

        const ImgEditCategury = document.querySelector("#EditCateguryImage").files[0];

        var input = new FormData();
        input.append("Image", ImgEditCategury)

        var EditCateguryRequest = $.ajax({
            type: "PUT",
            url: EditcateguryUrl,
            contentType: false,
            processData: false,
            enctype: "multipart/form-data",
            data: input,
            success: function (result) {

                console.log(result);

                appendLiveAlert(result.type, result.message);

                if (result.isSuccess) {
                    GetAllCateguryAdminPanel();
                }
            },
            error: function (xhr, status, strmessage) {
                console.log(`status request:  ${status} , str message: ${strmessage} `);
                console.log(xhr);
            }
        });
        EditCateguryRequest.done(function () { })
    });

    /// Product Concept
    $('[data-bs-target="#addProductBtnModal"]').click(GetCateguryOption("addProductSubCategury"));

    $('#addProductTitle').blur(function () {
        var request = $.ajax({
            url: `/api/Product/IsAnyProduct?ProductTitle=${$('#addProductTitle').val()}`,
            type: "POST",
            success: function (result) {
                //console.log(result);
                if (!(result === true)) {
                    appendLiveAlert("danger", result);
                }
            },
            error: function (xhr, status, Message) {
                console.log(`xhr : ${xhr}, status : ${status}, message : ${Message}`);
            }
        });
        request.done(function () { });
    });

    $("#addProductSubmit").on("submit", async function (e) {
        e.preventDefault();

        const AddProductUrl = "/api/Product/PostProduct";
        const ImgAddProduct = document.querySelector('#AddProductImage');

        var formdata = new FormData();
        formdata.append("ProductTitle", $("#addProductTitle").val());
        formdata.append("ProductDescription", $("#addProductDescription").val());
        formdata.append("productPrice", $("#addProductPrice").val());
        formdata.append("CateguryId", $("#addProductSubCategury").val());
        formdata.append("file", ImgAddProduct.files[0]);

        var addCateguryRequest = $.ajax({
            url: AddProductUrl,
            type: "POST",
            contentType: false,
            enctype: "multipart/form-data",
            processData: false,
            data: formdata,
            success: function (result) {
                console.log(result);
                appendLiveAlert(result.Type, result.message);

                if (result.isSuccess) {
                    setTimeout(() => {
                        GetAllProductAdminPanel();
                    }, 2500);
                }
            },
            error: function (xhr, status, strmessage) {
                console.log(`status request:  ${status} , str message: ${strmessage}`);
            }
        });
        addCateguryRequest.done(function () { })

    });

    $("#EditProductSubmit").on("submit", async function (e) {
        e.preventDefault();
        
        const EditProductUrl = "/api/Product/EditProduct ";
        const ImgEditProduct = document.querySelector('#editProductImage');
        //var id = $('#EditCategurySubmit').attr("data-id");

        var formdata = new FormData();
        formdata.append("ProductId", $(this).attr("data-id")); //only problem this part
        formdata.append("ProductTitle", $("#editProductTitle").val());
        formdata.append("ProductDescription", $("#editProductDescription").val());
        formdata.append("productPrice", $("#editProductPrice").val());
        formdata.append("CateguryId", $("#editProductSubCategury").val());
        formdata.append("file", ImgEditProduct.files[0]);
        formdata.append("IsWithDiscount", $("#IsWithDiscountEditProduct").is(":checked"));
        formdata.append("AfterDiscountPrice", $("#editProductWithDiscount").val());

        var addCateguryRequest = $.ajax({
            url: EditProductUrl,
            type: "POST",
            contentType: false,
            enctype: "multipart/form-data",
            processData: false,
            data: formdata,
            success: function (result) {
                //console.log(result);
                appendLiveAlert(result.Type, result.message);

                if (result.isSuccess) {
                    setTimeout(() => {
                        GetAllProductAdminPanel();
                    }, 2500);
                }
            },
            error: function (xhr, status, strmessage) {
                console.log(`status request:  ${status} , str message: ${strmessage}`);
            }
        });
        addCateguryRequest.done(function () { })

    });

})



