var dataTable;
//start function
$(document).ready(function () {
    //function to load data table
    loadDataTable();
});

function loadDataTable() {
    //we use de .DataTablefunction from the Table plug-in for jQuery
    //we can pass an ajax to it 
    dataTable = $('#DT_load').DataTable({ 
        "ajax": {
            // url is the route we defined in BookController
            "url": "/api/book",
            //type of ajax get or post
            "type": "GET",
            //type of data 
            "datatype": "json"
        },
        //columns is used to map the information in the table we use it as follows 
        "columns": [
            { "data": "name", "width": "20%" },
            { "data": "author", "width": "20%" },
            { "data": "isbn", "width": "20%" },
            {
                "data": "id",
                // The data that render.function return is what DataTables will use for the requested data type,
                //creates a link to the data source in this case edit and delete 
                "render": function (data) {
                    return `<div class = "text-center">
                            <a href="/BookList/Edit?id=${data}" class = 'btn btn-success text-white' style='cursor:pointer; width:70px;'>
                            Edit </a>
                            &nbsp;

                            <a  class = 'btn btn-danger text-white' style='cursor:pointer; width:70px;'
                            onclick=Delete('/api/book?id='+${data})>
                            Delete </a>
                            </div>`;
                    //column with
                }, "width": "40%"
            }
        ],
        //used to initialise the table
        "language": {
            "emptyTable": "no data found"
        },
        //table with
        "width": "100%"
    });
}
//function used on button delete
function Delete(url) {
    //sweet alert function swal devuelve un objeto promise al cual se le pueden adjuntar callbacks
    swal({
        title: "Are you sure?",
        text: "Once deleted, you will not be able to recover",
        icon: "warning",
        dangerMode: true
        //a javascript promise attached to swal,  
    }).then((willDelete) => {

        if (willDelete) {
            $.ajax({
                //we call the http delete we created in book controller 
                type: "DELETE",
                url: url,
                //if the id was found success will be true, otherwise it will be false
                success: function (data) {
                    if (data.success) {
                        //toast message showing success, it uses the library and stylesheet.jss
                        toastr.success(data.message);
                        //function tu reload table asynchronously
                        dataTable.ajax.reload();
                    }
                    else {
                        //toaster for an error
                        toastr.error(data.message);
                    }
                }
            })
        }

    })
}