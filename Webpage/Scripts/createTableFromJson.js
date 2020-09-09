function CreateTableFromJSON(staffJson){



    var col = [];
    var type;
    for (var i = 0; i < staffJson.length; i++) {
        for (var key in staffJson[i]) {
            if(key == 'StaffType'){

            }
            else if(key == 'Post'){
                type = 1;
            }
            else if((key == 'Subject') || (key == 'AssignedClass')){
                type = 0;
            }
            else if (col.indexOf(key) === -1) {
                col.push(key);
            }
        }
        
    }
    if(type == 0){
        col.push('Subject');
        col.push('AssignedClass');
    }
    else{
        col.push('Post');
    }
    //col.push('Delete');

    var table = document.createElement("table");
    

    var tr = table.insertRow(-1);  

    for (var i = 0; i < col.length; i++) {
        var th = document.createElement("th");      
        th.innerHTML = col[i];
        tr.appendChild(th);
    }

    var th = document.createElement("th");      
        th.innerHTML = 'Delete';
        tr.appendChild(th);


    for (var i = 0; i < staffJson.length; i++) {

        tr = table.insertRow(-1);
        var staffId;
        var staffType = staffJson[i]['StaffType'];
        for (var j = 0; j < col.length; j++) {
            var tabCell = tr.insertCell(-1);
            if(col[j] == 'StaffId'){
                staffId = staffJson[i][col[j]];
            }
            if(col[j] == 'Address'){
                tabCell.innerHTML = staffJson[i][col[j]]['HouseName'] + ', ' + staffJson[i][col[j]]['City'] + ', ' + staffJson[i][col[j]]['State'] + ', ' + staffJson[i][col[j]]['Pin'] ;
            }
            else{
                tabCell.innerHTML = staffJson[i][col[j]];
            }
        }

        var button = tr.insertCell(-1);
        var delButton = document.createElement("input");
        delButton.type = "button";
        delButton.value = "Delete";
        delButton.id = "delButton";
        delButton.name = staffId;
        delButton.dataset.type = staffType;
        delButton.onclick = function(){
            
            ToggleConfirmDeletePopUp(this.name,this.dataset.type);
        };
        button.appendChild(delButton);
    }

    return table;

    // var divContainer = document.getElementById("showData");
    //     divContainer.innerHTML = "";
    //     divContainer.appendChild(table);
}

