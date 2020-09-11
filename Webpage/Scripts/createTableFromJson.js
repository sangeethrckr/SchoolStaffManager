
function CreateTableFromJSON(staffJson){



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

    //var headContainer = document.createElement("tbody");

    for (var i = 0; i < col.length; i++) {
        var th = document.createElement("th");      
        th.innerHTML = col[i];
        tr.appendChild(th);
    }

    //tr.appendChild(headContainer);

    var th = document.createElement("th");      
    th.innerHTML = 'Delete';
    tr.appendChild(th);

    var th = document.createElement("th");      
    th.innerHTML = 'Update';
    tr.appendChild(th);


    for (var i = 0; i < staffJson.length; i++) {

        
        tr = table.insertRow(-1);
        var staffId = staffJson[i]['StaffId'];
        var staffType = staffJson[i]['StaffType'];
        //var container = document.createElement("tbody");

        for (var j = 0; j < col.length; j++) {
            var tabCell = tr.insertCell(-1);
            //var tabCell =document.createElement("td");
            
            if(col[j] == 'Address'){
                tabCell.innerHTML = staffJson[i][col[j]]['HouseName'] + ', ' + staffJson[i][col[j]]['City'] + ', ' + staffJson[i][col[j]]['State'] + ', ' + staffJson[i][col[j]]['Pin'] ;
            }
            else{
                tabCell.innerHTML = staffJson[i][col[j]];
            }
            //container.appendChild(tabCell);
        }

        //tr.appendChild(container);

        var button = tr.insertCell(-1);
        var delButton = document.createElement("input");
        delButton.type = "button";
        delButton.value = "Delete";
        delButton.id = "delButton";
        delButton.dataset.staffId = staffId;
        delButton.dataset.type = staffType;
        delButton.onclick = function(){
            
            ToggleConfirmDeletePopUp(this.dataset.staffId,this.dataset.type);
        };

        button.appendChild(delButton);


        var button = tr.insertCell(-1);
        var updateButton = document.createElement("input");
        updateButton.type = "button";
        updateButton.value = "Update";
        updateButton.id = "updateButton";
        updateButton.dataset.staffId = staffJson[i]['StaffId'];
        updateButton.dataset.name = staffJson[i]['Name'];
        updateButton.dataset.housename = staffJson[i]['Address']['HouseName'];
        updateButton.dataset.city = staffJson[i]['Address']['City'];
        updateButton.dataset.state = staffJson[i]['Address']['State'];
        updateButton.dataset.pin = staffJson[i]['Address']['Pin'];
        updateButton.dataset.phoneNumber = staffJson[i]['PhoneNumber'];
        updateButton.dataset.salary = staffJson[i]['Salary'];
        if(staffType == 0){
            updateButton.dataset.subject = staffJson[i]['Subject'];
            updateButton.dataset.classAssigned = staffJson[i]['AssignedClass'];
        }
        else{
            updateButton.dataset.post = staffJson[i]['Post'];
        }
        updateButton.onclick = function(){
            
            if(parseInt(staffType) == 0 ){
                ToggleCreateTeacherPopUp(2,this.dataset.staffId,this.dataset.name,this.dataset.housename,this.dataset.city,this.dataset.state,this.dataset.pin,this.dataset.phoneNumber,this.dataset.salary,this.dataset.subject,this.dataset.classAssigned);
            }
            else{
                ToggleCreateAdminOrSupportStaffPopUp(2,this.dataset.staffId,this.dataset.name,this.dataset.housename,this.dataset.city,this.dataset.state,this.dataset.pin,this.dataset.phoneNumber,this.dataset.salary,this.dataset.post);
            }
        };

        button.appendChild(updateButton);

    }

    return table;


}










// tr.dataset.staffId = staffJson[i]['StaffId'];
// tr.dataset.name = staffJson[i]['Name'];
// tr.dataset.housename = staffJson[i]['Address']['HouseName'];
// tr.dataset.city = staffJson[i]['Address']['City'];
// tr.dataset.state = staffJson[i]['Address']['State'];
// tr.dataset.pin = staffJson[i]['Address']['Pin'];
// tr.dataset.phoneNumber = staffJson[i]['PhoneNumber'];
// tr.dataset.salary = staffJson[i]['Salary'];
// tr.onclick = function() {
    
//     if(parseInt(staffType) == 0 ){
//         ToggleCreateTeacherPopUp(2,this.dataset.staffId);
//     }
//     else{
//         ToggleCreateAdminOrSupportStaffPopUp(2,this.dataset.staffId,this.dataset.name,this.dataset.housename,this.dataset.city,this.dataset.state,this.dataset.pin,this.dataset.phoneNumber,this.dataset.salary);
//     }
// }



// function CreateTableFromJSON(staffJson){



//     var col = [];
//     var type;
//     for (var i = 0; i < staffJson.length; i++) {
//         for (var key in staffJson[i]) {
//             if((key == 'StaffType')||(key == 'StaffId')){

//             }
//             else if(key == 'Post'){
//                 type = 1;
//             }
//             else if((key == 'Subject') || (key == 'AssignedClass')){
//                 type = 0;
//             }
//             else if (col.indexOf(key) === -1) {
//                 col.push(key);
//             }
//         }
        
//     }
//     if(type == 0){
//         col.push('Subject');
//         col.push('AssignedClass');
//     }
//     else{
//         col.push('Post');
//     }
  

//     var table = document.createElement("div");
    
    

//     var tr = document.createElement("div");
//     tr.className = "headingRow";

//     var headContainer = document.createElement("div");

//     for (var i = 0; i < col.length; i++) {
//         var th = document.createElement("div"); 
//         th.className = "heading";     
//         th.innerHTML = col[i];
//         headContainer.appendChild(th);
//     }

//     tr.appendChild(headContainer);
    

//     var th = document.createElement("div");   
//     th.className = "heading";   
//     th.innerHTML = 'Delete';
//     tr.appendChild(th);


//     table.appendChild(tr);

//     for (var i = 0; i < staffJson.length; i++) {

        
//         tr = document.createElement("div");
//         tr.className = "row";
//         var staffId = staffJson[i]['StaffId'];
//         var staffType = staffJson[i]['StaffType'];
//         var container = document.createElement("div");

//         for (var j = 0; j < col.length; j++) {
//             //var tabCell = tr.insertCell(-1);
//             var tabCell =document.createElement("div");
            
//             if(col[j] == 'Address'){
//                 tabCell.innerHTML = staffJson[i][col[j]]['HouseName'] + ', ' + staffJson[i][col[j]]['City'] + ', ' + staffJson[i][col[j]]['State'] + ', ' + staffJson[i][col[j]]['Pin'] ;
//             }
//             else{
//                 tabCell.innerHTML = staffJson[i][col[j]];
//             }
//             container.appendChild(tabCell);
//         }

//         tr.appendChild(container);

//         //var button = tr.insertCell(-1);
//         var delButton = document.createElement("input");
//         delButton.type = "button";
//         delButton.value = "Delete";
//         delButton.id = "delButton";
//         delButton.dataset.staffId = staffId;
//         delButton.dataset.type = staffType;
//         delButton.onclick = function(){
            
//             ToggleConfirmDeletePopUp(this.dataset.staffId,this.dataset.type);
//         };

//         tr.appendChild(delButton);
//         table.appendChild(tr);

//     }

//     return table;


// }



// for (var i = 0; i < staffJson.length; i++) {

        
//     tr = table.insertRow(-1);
//     var staffId = staffJson[i]['StaffId'];
//     var staffType = staffJson[i]['StaffType'];
    

//     for (var j = 0; j < col.length; j++) {
//         var tabCell = tr.insertCell(-1);
        
//         if(col[j] == 'Address'){
//             tabCell.innerHTML = staffJson[i][col[j]]['HouseName'] + ', ' + staffJson[i][col[j]]['City'] + ', ' + staffJson[i][col[j]]['State'] + ', ' + staffJson[i][col[j]]['Pin'] ;
//         }
//         else{
//             tabCell.innerHTML = staffJson[i][col[j]];
//         }
//     }

//     var button = tr.insertCell(-1);
//     var delButton = document.createElement("input");
//     delButton.type = "button";
//     delButton.value = "Delete";
//     delButton.id = "delButton";
//     delButton.dataset.staffId = staffId;
//     delButton.dataset.type = staffType;
//     delButton.onclick = function(){
        
//         ToggleConfirmDeletePopUp(this.dataset.staffId,this.dataset.type);
//     };
