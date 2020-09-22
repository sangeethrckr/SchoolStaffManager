
function CreateTableFromJSON(staffJson,start,end){

    var col = [];
    var type;
    for (var i = 0; i < staffJson.length; i++) {
        for (var key in staffJson[i]) {
            if((key == 'StaffType')||(key == 'StaffId')){

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

    for (var i = start; i < end; i++) {

        tr = table.insertRow(-1);
        var staffId = staffJson[i]['StaffId'];
        var staffType = staffJson[i]['StaffType'];
        
        for (var j = 0; j < col.length; j++) {

            var tabCell = tr.insertCell(-1);
            
            if(col[j] == 'Address'){
                tabCell.innerHTML = staffJson[i][col[j]]['HouseName'] + ', ' + staffJson[i][col[j]]['City'] + ', ' + staffJson[i][col[j]]['State'] + ', ' + staffJson[i][col[j]]['Pin'] ;
            }
            else{
                tabCell.innerHTML = staffJson[i][col[j]];
            }
            
        }

        
        var cell = tr.insertCell(-1);
        var delButton = document.createElement("input");
        delButton.type = "button";
        delButton.value = "Delete";
        delButton.id = "delButton";
        delButton.dataset.staffId = staffId;
        delButton.dataset.type = staffType;
        delButton.onclick = function(){
            event.stopPropagation();
            ToggleConfirmPopUp(this.dataset.staffId,this.dataset.type);
        };

        cell.appendChild(delButton);

        
        tr.dataset.staffId = staffJson[i]['StaffId'];
        tr.dataset.name = staffJson[i]['Name'];
        tr.dataset.housename = staffJson[i]['Address']['HouseName'];
        tr.dataset.city = staffJson[i]['Address']['City'];
        tr.dataset.state = staffJson[i]['Address']['State'];
        tr.dataset.pin = staffJson[i]['Address']['Pin'];
        tr.dataset.phoneNumber = staffJson[i]['PhoneNumber'];
        tr.dataset.salary = staffJson[i]['Salary'];
        tr.dataset.post = 0;
        tr.dataset.subject = 0;
        tr.dataset.classAssigned = 0;
        if(staffType == 0){
            tr.dataset.subject = staffJson[i]['Subject'];
            tr.dataset.classAssigned = staffJson[i]['AssignedClass'];
        }
        else{
            tr.dataset.post = staffJson[i]['Post'];
        }
        tr.onclick = function(){
            
            ToggleFormPopup(staffType,2,this.dataset.staffId,this.dataset.name,this.dataset.housename,this.dataset.city,this.dataset.state,this.dataset.pin,this.dataset.phoneNumber,this.dataset.salary,this.dataset.post,this.dataset.subject,this.dataset.classAssigned);
        };

    }

    return table;

}










