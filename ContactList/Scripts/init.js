function renderTable(results) {
    //https://codepen.io/js-ziggle/pen/pypLza

    var container = document.getElementById("example");
    var hot = new Handsontable(container, {
        data: results,
        rowHeaders: true,
        colHeaders: [
            'ID',
            'Who',
            'Status',
            'Company',
            'Ind',
            'First',
            'Last',
            'Position',
            'Phone',
            'Email'
        ],
        //columns: [
        //    {
        //        data: 'ID',
        //        type: 'numeric'
        //    }, {
        //        data: 'Who',
        //        type: 'text'
        //    }, {
        //        data: 'Status',
        //        type: 'text'
        //    }, {
        //        data: 'Company',
        //        type: 'text'
        //    }, {
        //        data: 'Ind',
        //        type: 'text'
        //    }, {
        //        data: 'First',
        //        type: 'text'
        //    }, {
        //        data: 'Last',
        //        type: 'text'
        //    }, {
        //        data: 'Position',
        //        type: 'text'
        //    }, {
        //        data: 'Phone',
        //        type: 'text'
        //    }, {
        //        data: 'Email',
        //        type: 'text'
        //    }
        //],
        filters: true,
        dropdownMenu: true,
        manualRowResize: true,
        manualColumnResize: true,
        contextMenu: true,
        multiColumnSorting: {
            indicator: true
        },
        autoColumnSize: {
            samplingRatio: 23
        },
        exportFile: true,
        licenseKey: 'non-commercial-and-evaluation',
        allowInsertRow: true,   
        allowRemoveRow: true,
        allowInsertColumn: true,
        allowRemoveColumn: true,
        afterChange: function (changes, source) {
            if (source === 'edit') {
                var result = document.getElementById('info');
                //Handsontable.Dom.empty(result);

                // changes[0][0] -> Row number (starting from 0)
                // changes[0][1] -> Column header name
                // changes[0][2] -> Original Data
                // changes[0][3] -> New data
                var id = changes[0][0] + 1;
                var columnHeader = changes[0][1];
                var oldData = changes[0][2];
                var newData = changes[0][3];
                if (oldData != newData)
                    editCell(id, columnHeader, newData);
                // call method (id, columnHeader, oldData, newData)
                // id = row number + 1
                result.innerText = changes[0][0] + " " + changes[0][1] + " " + changes[0][2] + " " + changes[0][3];;
            }
        }
    });
}

function editCell(id, columnHeader, newData) {
    $.ajax({
        url: "/Contact/UpdateData",
        type: "POST",
        data: {
            id: id,
            columnHeader: columnHeader,
            newData: newData
        },
        success: function (data) {
            renderTable(JSON.parse(data));
        }
    });
}