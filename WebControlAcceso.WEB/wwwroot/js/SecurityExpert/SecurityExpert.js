let ide;
let id;
let customIds;
let accessLevelsId = {
    IdAccess: []
};
let accessLevelsIds = {
    IdAccess: []
};
let accessLevelsIdUser = {
    IdAccess: []
};
let tarjetsAsign = {};
let cont = 0;
let dataUser = {};

$(document).ready(async function () {
    const names = getParameterByName('names');
    const lastName = getParameterByName('lastName');
    chargeDate();
    if (names && lastName) {
        ide = getParameterByName('Ide');
        id = getParameterByName('id');
        document.getElementById('nombresVis').value = names;
        document.getElementById('apellidosVis').value = lastName;
        document.getElementById('nombresYapellidos').value = names + ' ' + lastName;
    }
    alertSuccess();
    await fillControls();
    await getAllPeople();
    getRecordGroups();
    $(function () {
        $('.select2').select2();
        $(".select2-placeholder-multiple").select2({
            placeholder: "Select State"
        });
    });
    getTarjetAsign();
});

function chargeDate() {
    n = new Date();
    y = n.getFullYear();
    m = n.getMonth() + 1;
    d = n.getDate();
    var fecha = d + "-" + m + "-" + y;
    document.getElementById("initdate").value = fecha;
    document.getElementById("enddate").innerHTML = d + "-" + m + "-" + y;
}

function checkInitChange() {
    document.getElementById("initdate").disabled = false;
}

function checkEndChange() {
    document.getElementById("enddate").disabled = false;
}

function getParameterByName(name, url = window.location.href) {
    name = name.replace(/[\[\]]/g, '\\$&');
    var regex = new RegExp('[?&]' + name + '(=([^&#]*)|&|#|$)'),
        results = regex.exec(url);
    if (!results) return null;
    if (!results[2]) return '';
    return decodeURIComponent(results[2].replace(/\+/g, ' '));
}

function addTarjet() {
    var html = "";
    if (cont <= 7) {
        html += '<form id="tarjetsForm' + cont + '"><div class="row" ><div class="col-xl-3"><div class="col-md-12 mb-3" style="text-align: center; padding: 7px;"><label class="form-label">Numero de tarjeta ' + cont + '</label>'
            + '</div></div><div class="col-xl-3"><div class="col-md-12 mb-3"><input type="text" id="loteTarjet' + cont + '" class="form-control" placeholder="000" name="familyNumber"></div></div><div class="col-xl-3"><div class="col-md-12 mb-3">'
            + '<input type="text" id="numberTarjet' + cont + '" class="form-control" placeholder="000" name="cardNumber"></div></div>'
            + '<div class="col-xl-3"><div class="col-md-12 mb-3" style="padding: 5px;"><div class="custom-control custom-radio mb-2">'
            + '<div class="custom-control custom-checkbox"><input type="checkbox" class="custom-control-input" id="tarjet' + cont + '">'
            + '<label class="custom-control-label" for= "tarjet' + cont + '">Deshabilitar</label ></div ></div ></div ></div ></div ></form>';
        cont++;
        $("#tarjets").append(html);
    } else {
        toastEror(" Ya asignó el número de tarjetas permitodo.");
    }
}

function completeNames(val) {
    const names = document.getElementById("nombresVis").value;
    const lastNames = document.getElementById("apellidosVis").value;
    $("#nombresVis").keyup(function () {
        var value = $(this).val();
        $("#nombresYapellidos").val(value);
    });

    $("#apellidosVis").keyup(function () {
        var value = names + ' ' + $(this).val();
        $("#nombresYapellidos").val(value);
    });
}

async function getRecordGroups() {
    await $.ajax({
        async: true,
        url: 'SecurityExpert/GetRecordGruops',
        data: '',
        type: "POST",
        success: function (data) {
            if (data.length > 0) {
                a = document.querySelector("#recordGroup");
                for (var i = 0; i < data.length; i++) {
                    op = document.createElement("option");
                    op.value = data[i].recordGroupId;
                    op.text = data[i].name;
                    a.add(op);
                }
                //$("#recordGroup").val("5");
            } else {
                toastEror();
            }
        },
        error: function (data) {

        }
    });
}

function getTarjetAsign() {
    $.ajax({
        async: true,
        url: 'SecurityExpert/GetAsignTarjet',
        data: '',
        type: "POST",
        success: function (data) {
            if (data.length > 0) {
                tarjetsAsign = data;
            } else {
                toastEror();
            }
        },
        error: function (data) {

        }
    });
}

function addHtmlLvlAccess() {
    debugger;
    var ids = [];
    for (var i = 0; i < accessLevelsId.IdAccess.length; i++) {
        if (accessLevelsId.IdAccess[i] !== accessLevelsIds.IdAccess[i]) {
            var obj = {};
            let checkBoxCheck = $("#s" + accessLevelsId.IdAccess[i]);
            if (checkBoxCheck.is(':checked')) {
                obj['accessLevelId'] = accessLevelsId.IdAccess[i];
            }
            ids.push(obj);
        } 
    }
    
    $.ajax({
        async: true,
        url: 'SecurityExpert/GetLevelsById',
        data: { jsonobtj: JSON.stringify(ids) },
        type: "POST",
        success: function (data) {
            if (data.length > 0) {
                n = new Date();
                y = n.getFullYear();
                m = n.getMonth() + 1;
                d = n.getDate();
                var fecha = d + "-" + m + "-" + y;
                var html = "";
                var cont = 0;
                var obj = {};
                data.forEach(function (valor, indice, array) {
                    cont++;
                    html += '<form id ="accessLevels' + valor.accessLevelId + '"><div class="row"><div class="col-xl-2"></div><div class="col-xl-2"><div class="custom-control custom-checkbox"> <input type="checkbox" class="custom-control-input" id="'
                        + valor.accessLevelId + '" name="userAccessLevel" checked><label class="custom-control-label" for="' + valor.accessLevelId + '">' + valor.name +
                        '</label></div></div><div class="col-xl-2"><div class="custom-control custom-checkbox"> <input type="checkbox" class="custom-control-input" id="Active'
                        + valor.accessLevelId + '" name="dateActive" checked><label class="custom-control-label" for="Active' + valor.accessLevelId + '">' + "Active" +
                        '</label></div></div><div class="col-xl-2"><label class="form-label">Fecha Inicio - Fecha Fin</label></div><div class="col-xl-4"><div class="input-daterange input-group" id="datepicker-' + cont + '" name="fechas"> <input type="text" class="form-control" name="userAccessLevelStart"> <div class="input-group-append input-group-prepend"> <span class="input-group-text fs-xl"><i class="@(Settings.Theme.IconPrefix) fa-ellipsis-h"></i></span></div><input type="text" class="form-control" name="userAccessLevelEnd"></div></div></div></form>';
                    obj = valor.accessLevelId;
                    accessLevelsIds['IdAccess'].push(obj);
                });

                $("#levelAccesOn").append(html);
                for (var i = 1; i <= data.length; i++) {
                    runDatePicker("datepicker-" + i);
                }
                toastSucces("Cargado con Exito!");
            } else {
                toastEror(" No hay niveles de acceso por agregar o ya fueron agregados.");
            }
        },
        error: function (data) {

        }
    });
}

function addSecurity() {
    const elements = document.getElementById("tarjets").elements;
    const objTarjets = {};

    var obj = {
        UserInfo: [],
        Dependency: [],
        InfoTarjet: [],
        LevelAccess: []
    };
    debugger;
    for (var i = 0; i < cont; i++) {
        let it = document.getElementById('numberTarjet' + i + '').value;
        let tarjet = tarjetsAsign.find(element => element == it);
        if (tarjet) {
            toastEror(" El número de tarjeta " + i + " ya está asignado!");
            return;
        }
        let objTarjetss = {};
        var elementst = document.getElementById("tarjetsForm" + i + "").elements;
        var init = document.getElementById("initdate").value;
        var end = document.getElementById("enddate").value;
        let checkBoxCheck = $("#tarjet" + i);
        let checkBoxCheckInit = $("#initDateCheck");
        let checkBoxCheckEnd = $("#endDateCheck");
        let n = new Date();
        let y = n.getFullYear();
        let m = n.getMonth() + 1;
        let d = n.getDate();
        var fecha = "";
        if (m < 10) {
          fecha = `${d}/0${m}/${y}`
        } else {
           fecha = `${d}/${m}/${y}`
        }
       
        for (var o = 0; o < elementst.length; o++) {
            if (checkBoxCheck.is(':checked')) {
                objTarjetss['cardDisabled'] = true;
            } else {
                objTarjetss['cardDisabled'] = false;
            }
            if (checkBoxCheckInit.is(':checked')) {
                objTarjetss['Init'] = true;
            } else {
                objTarjetss['Init'] = false;
            }
            if (checkBoxCheckEnd.is(':checked')) {
                objTarjetss['End'] = true;
            } else {
                objTarjetss['End'] = false;
            }
            var item = elementst.item(o);
            objTarjetss[item.name] = item.value;
        }
        obj['InfoTarjet'].push(objTarjetss);
    }

    for (var i = 0; i < accessLevelsIds.IdAccess.length; i++) {
        let objAccess = {};
        var elementsAccess = document.getElementById("accessLevels" + accessLevelsId.IdAccess[i] + "").elements;
        let checkBoxCheck = $("#" + accessLevelsId.IdAccess[i]);
        let checkBoxCheckActive = $("#Active" + accessLevelsId.IdAccess[i]);
        if (checkBoxCheck.is(':checked')) {
            for (var e = 0; e < elementsAccess.length; e++) {
                let item = elementsAccess.item(e);
                if (checkBoxCheckActive.is(':checked')) {
                    objAccess['UserAccessLevelExpire'] = true;
                } else {
                    objAccess['UserAccessLevelExpire'] = false;
                }
                objAccess['userAccessLevel'] = checkBoxCheck[0].id.replace("'", "");
                if (item.name != 'userLevelAccess') {
                    objAccess[item.name] = item.value;
                }
            }
            obj['LevelAccess'].push(objAccess);
        }
    }

    var objUserInfo = {};
    objUserInfo['SiteID'] = document.getElementById('Sites').value;
    objUserInfo['UserId'] = id;
    objUserInfo['LastName'] = document.getElementById('apellidosVis').value;
    objUserInfo['FirstName'] = document.getElementById('nombresVis').value;
    objUserInfo['RecordGroup'] = document.getElementById('recordGroup').value;
    obj['UserInfo'].push(objUserInfo);

    var objDependency = {
        Area: [],
        Identificacion: [],
        Dependencia: []
    };
    var objArea = {};
    objArea['CustomFieldID'] = 3;
    objArea['CustomFieldType'] = 7;
    objArea['UserCustomFieldGroupDataID'] = 0;
    objArea['CustomFieldNumericalData'] = document.getElementById('Combo3').value;
    objArea['CustomFieldTextData'] = '';
    objArea['Site'] = document.getElementById('Sites').value;
    objDependency['Area'].push(objArea);

    var objDependencia = {};
    objDependencia['CustomFieldID'] = 4;
    objDependencia['CustomFieldType'] = 7;
    objDependencia['UserCustomFieldGroupDataID'] = 0;
    objDependencia['CustomFieldNumericalData'] = document.getElementById('Combo4').value;
    objDependencia['CustomFieldTextData'] = '';
    objDependencia['Site'] = document.getElementById('Sites').value;
    objDependency['Dependencia'].push(objDependencia);

    var objIdentificacion = {};
    objIdentificacion['CustomFieldID'] = 0;
    objIdentificacion['CustomFieldType'] = 0;
    objIdentificacion['UserCustomFieldGroupDataID'] = 0;
    objIdentificacion['CustomFieldNumericalData'] = 0;
    objIdentificacion['CustomFieldTextData'] = document.getElementById('0').value;
    objIdentificacion['Site'] = document.getElementById('Sites').value;
    objDependency['Identificacion'].push(objIdentificacion);
    obj['Dependency'].push(objDependency);
    let objData = JSON.stringify(obj);

    $.ajax({
        url: 'SecurityExpert/AddSecurity',
        data: { jsonobtj: objData },
        type: "POST",
        success: function (data) {
            if (data == true) {
                toastSucces("Agregado con Exito!");
            } else {
                toastEror();
            }
        },
        error: function (data) {
            toastEror();
        }
    });
}

function updateSecurity() {
    var obj = {
        UserInfo: [],
        Dependency: [],
        InfoTarjet: [],
        LevelAccess: []
    };
    debugger;
    for (var i = 0; i < cont; i++) {
        //let it = document.getElementById('numberTarjet' + i + '').value;
        //let tarjet = tarjetsAsign.find(element => element == it);
        //if (tarjet) {
        //    toastEror(" El número de tarjeta " + i + " ya está asignado!");
        //    return;
        //}
        let objTarjetss = {};
        var elementst = document.getElementById("tarjetsForm" + i + "").elements;
        var init = document.getElementById("initdate").value;
        var end = document.getElementById("enddate").value;
        let checkBoxCheck = $("#tarjet" + i);
        for (var o = 0; o < elementst.length; o++) {
            if (checkBoxCheck.is(':checked')) {
                objTarjetss['cardDisabled'] = 1;
            } else {
                objTarjetss['cardDisabled'] = 0;
            }
            var item = elementst.item(o);
            objTarjetss[item.name] = item.value;
            objTarjetss['startDate'] = init;
            objTarjetss['expiritDate'] = end;
        }
        obj['InfoTarjet'].push(objTarjetss);
    }

    for (var i = 0; i < accessLevelsIdUser.IdAccess.length; i++) {
        let objAccess = {};
        var elementsAccess = document.getElementById("accessLevels" + accessLevelsIdUser.IdAccess[i] + "").elements;
        let checkBoxCheck = $("#" + accessLevelsIdUser.IdAccess[i]);
        if (checkBoxCheck.is(':checked')) {
            for (var e = 0; e < elementsAccess.length; e++) {
                let item = elementsAccess.item(e);
                objAccess['userAccessLevel'] = checkBoxCheck[0].id.replace("'", "");
                if (item.name != 'userLevelAccess') {
                    objAccess[item.name] = item.value;
                }
            }
            obj['LevelAccess'].push(objAccess);
        }
    }

    var objUserInfo = {};
    objUserInfo['SiteID'] = document.getElementById('Sites').value;
    objUserInfo['UserId'] = id;
    objUserInfo['LastName'] = document.getElementById('apellidosVis').value;
    objUserInfo['FirstName'] = document.getElementById('nombresVis').value;
    objUserInfo['RecordGroup'] = document.getElementById('recordGroup').value;
    obj['UserInfo'].push(objUserInfo);

    var objDependency = {
        Area: [],
        Identificacion: [],
        Dependencia: []
    };
    var objArea = {};
    objArea['CustomFieldID'] = 3;
    objArea['CustomFieldType'] = 7;
    objArea['UserCustomFieldGroupDataID'] = 0;
    objArea['CustomFieldNumericalData'] = document.getElementById('Combo0').value;
    objArea['CustomFieldTextData'] = '';
    objArea['Site'] = document.getElementById('Sites').value;
    objDependency['Area'].push(objArea);

    var objDependencia = {};
    objDependencia['CustomFieldID'] = 4;
    objDependencia['CustomFieldType'] = 7;
    objDependencia['UserCustomFieldGroupDataID'] = 0;
    objDependencia['CustomFieldNumericalData'] = document.getElementById('Combo4').value;
    objDependencia['CustomFieldTextData'] = '';
    objDependencia['Site'] = document.getElementById('Sites').value;
    objDependency['Dependencia'].push(objDependencia);

    var objIdentificacion = {};
    objIdentificacion['CustomFieldID'] = 0;
    objIdentificacion['CustomFieldType'] = 0;
    objIdentificacion['UserCustomFieldGroupDataID'] = 0;
    objIdentificacion['CustomFieldNumericalData'] = 0;
    objIdentificacion['CustomFieldTextData'] = document.getElementById('2').value;
    objIdentificacion['Site'] = document.getElementById('Sites').value;
    objDependency['Identificacion'].push(objIdentificacion);
    obj['Dependency'].push(objDependency);
    let objData = JSON.stringify(obj);

    $.ajax({
        url: 'SecurityExpert/UpdateSecurity',
        data: { jsonobtj: objData },
        type: "POST",
        success: function (data) {
            if (data == true) {
                toastSucces("Agregado con Exito!");
            } else {
                toastEror();
            }
        },
        error: function (data) {
            toastEror();
        }
    });
}

async function levelAccesGenerate(siteId) {
    await $.ajax({
        async: true,
        url: 'SecurityExpert/GetLevelSites',
        data: { jsonobtj: siteId },
        type: "POST",
        success: function (data) {
            if (data.length > 0) {
                n = new Date();
                y = n.getFullYear();
                m = n.getMonth() + 1;
                d = n.getDate();
                var fecha = d + "-" + m + "-" + y;
               // $("#levelAccessOn").html("");
                var html = "";
                var cont = 0;
                var obj = {};
                data.forEach(function (valor, indice, array) {
                    cont++;
                    html += '<form id ="accessLevelss' + valor.accessLevelID + '"><div class="row"><div class="col-xl-2"></div><div class="col-xl-2"><div class="custom-control custom-checkbox"> <input type="checkbox" class="custom-control-input" id="s'
                        + valor.accessLevelID + '" name="userAccessLevel"><label class="custom-control-label" for="s' + valor.accessLevelID + '">' + valor.name +
                        '</label></div></div><div class="col-xl-2"><div class="custom-control custom-checkbox"> <input type="checkbox" class="custom-control-input" id="Actives'
                        + valor.accessLevelID + '" name="dateActive"><label class="custom-control-label" for="Active' + valor.accessLevelID + '">' + "Active" +
                        '</label></div></div><div class="col-xl-2"><label class="form-label">Fecha Inicio - Fecha Fin</label></div><div class="col-xl-4"><div class="input-daterange input-group" id="datepicker-' + cont + '" name="fechas"> <input type="text" class="form-control" name="userAccessLevelStart"> <div class="input-group-append input-group-prepend"> <span class="input-group-text fs-xl"><i class="@(Settings.Theme.IconPrefix) fa-ellipsis-h"></i></span></div><input type="text" class="form-control" name="userAccessLevelEnd"></div></div></div></form>';
                    obj = valor.accessLevelID;
                    accessLevelsId['IdAccess'].push(obj);
                });

                $("#modalLvl").append(html);
                for (var i = 1; i <= data.length; i++) {
                    runDatePicker("datepicker-" + i);
                    //document.getElementById("datepicker-" + i).value = fecha;
                }
                toastSucces("Cargado con Exito!");
            } else {
                toastEror(" Con los niveles de acceso");
            }
        },
        error: function (data) {

        }
    });
}

function addLevelAccessChange() {
    const siteId = document.getElementById('Sites').value
    $.ajax({
        async: true,
        url: 'SecurityExpert/GetLevelSites',
        data: { jsonobtj: siteId },
        type: "POST",
        success: function (data) {
            if (data.length > 0) {
                n = new Date();
                y = n.getFullYear();
                m = n.getMonth() + 1;
                d = n.getDate();
                var fecha = d + "-" + m + "-" + y;
               //$("#LevelAccessOff").html("");
                var html = "";
                var cont = 0;
                var obj = {};
                data.forEach(function (valor, indice, array) {
                    cont++;
                    html += '<form id ="accessLevels' + valor.accessLevelID + '"><div class="row"><div class="col-xl-2"></div><div class="col-xl-2"><div class="custom-control custom-checkbox"> <input type="checkbox" class="custom-control-input" id="'
                        + valor.accessLevelID + '" name="userAccessLevel"><label class="custom-control-label" for="' + valor.accessLevelID + '">' + valor.name +
                        '</label></div></div><div class="col-xl-2"><div class="custom-control custom-checkbox"> <input type="checkbox" class="custom-control-input" id="Active'
                        + valor.accessLevelID + '" name="dateActive"><label class="custom-control-label" for="Active' + valor.accessLevelID + '">' + "Active" +
                        '</label></div></div><div class="col-xl-2"><label class="form-label">Fecha Inicio - Fecha Fin</label></div><div class="col-xl-4"><div class="input-daterange input-group" id="datepicker-' + cont + '" name="fechas"> <input type="text" class="form-control" name="userAccessLevelStart"> <div class="input-group-append input-group-prepend"> <span class="input-group-text fs-xl"><i class="@(Settings.Theme.IconPrefix) fa-ellipsis-h"></i></span></div><input type="text" class="form-control" name="userAccessLevelEnd"></div></div></div></form>';
                    obj = valor.accessLevelID;
                    accessLevelsId['IdAccess'].push(obj);
                });

                $("#modalLvl").append(html);
                for (var i = 1; i <= data.length; i++) {
                    runDatePicker("datepicker-" + i);
                    document.getElementById("datepicker-" + i).value = fecha;
                }
                toastSucces("Cargado con Exito!");
            } else {
                toastEror(" Con los niveles de acceso");
            }
        },
        error: function (data) {

        }
    });
}

function change() {
    debugger;
    let UserID = document.getElementById("selectPeople").value;
    id = UserID;
    let x = document.getElementById("updateButton");
    if (x.style.display === 'none') {
        x.style.display = 'block';
    } else {
        x.style.display = 'none';
    }
    let y = document.getElementById("saveButton");
    if (y.style.display === 'none') {
        y.style.display = 'block';
    } else {
        y.style.display = 'none';
    }
    let ud = dataUser.find(element => element.userId == UserID);
    $("#nombresYapellidos").val(ud.firstName + " " + ud.lastName);
    $("#nombresVis").val(ud.firstName);
    $("#apellidosVis").val(ud.lastName);
    $("#recordGroup").val(ud.recordGroup);
    $("#initdate").val(ud.startDate.split('T')[0]);
    $("#enddate").val(ud.expiritDate.split('T')[0]);
    $("#Sites").val(ud.siteId);
    getCustomFields(ud.siteId);
    var obj = {};
    obj['UserID'] = UserID;
    $.ajax({
        url: 'SecurityExpert/GetInfoUser',
        data: { jsonobtj: JSON.stringify(obj) },
        type: "POST",
        success: function (data) {
            if (data != null) {

                if (data.access.length > 0) {
                    $("#levelAccesOn").html("");
                    var html = "";
                    var contl = 0;
                    var obj = {};
                    data.access.forEach(function (valor, indice, array) {
                        contl++;
                        html += '<form id ="accessLevels' + valor.accessLevelId + '"><div class="row"><div class="col-xl-2"></div><div class="col-xl-2"><div class="custom-control custom-checkbox"> <input type="checkbox" class="custom-control-input" id="'
                            + valor.accessLevelId + '" name="userAccessLevel" checked><label class="custom-control-label" for="' + valor.accessLevelId + '">' + valor.name +
                            '</label></div></div><div class="col-xl-2"><div class="custom-control custom-checkbox"> <input type="checkbox" class="custom-control-input" id="Active'
                            + valor.accessLevelId + '" name="dateActive"><label class="custom-control-label" for="Active' + valor.accessLevelId + '">' + "Active" +
                            '</label></div></div><div class="col-xl-2"><label class="form-label">Fecha Inicio - Fecha Fin</label></div><div class="col-xl-4"><div class="input-daterange input-group" id="datepicker-' + cont + '" name="fechas"> <input type="text" class="form-control" name="userAccessLevelStart"> <div class="input-group-append input-group-prepend"> <span class="input-group-text fs-xl"><i class="@(Settings.Theme.IconPrefix) fa-ellipsis-h"></i></span></div><input type="text" class="form-control" name="userAccessLevelEnd"></div></div></div></form>';
                        obj = valor.userAccessLevel;
                        accessLevelsIdUser['IdAccess'].push(obj);
                    });
                    $("#levelAccesOn").append(html);
                    for (var i = 1; i <= data.access.length; i++) {
                        runDatePicker("datepicker-" + i);
                    }
                }

                if (data.cards.length > 0) {
                    var html = "";
                    data.cards.forEach(function (valorCard, indiceCard, array) {
                        html += '<form id="tarjetsForm' + indiceCard + '"><div class="row" ><div class="col-xl-3"><div class="col-md-12 mb-3" style="text-align: center; padding: 7px;"><label class="form-label">Numero de tarjeta ' + indiceCard + '</label>'
                            + '</div></div><div class="col-xl-3"><div class="col-md-12 mb-3"><input type="text" class="form-control" id="loteTarjet' + indiceCard + '" name="familyNumber" placeholder="' + valorCard.familyNumber + '">'
                            + '</div></div><div class="col-xl-3"><div class="col-md-12 mb-3">'
                            + '<input type="text" id="numberTarjet' + indiceCard + '" class="form-control" placeholder="' + valorCard.cardNumber + '" name="cardNumber"></div></div>'
                            + '<div class="col-xl-3"><div class="col-md-12 mb-3" style="padding: 5px;"><div class="custom-control custom-radio mb-2">'
                            + '<div class="custom-control custom-checkbox"><input type="checkbox" class="custom-control-input" id="tarjet' + indiceCard + '">'
                            + '<label class="custom-control-label" for= "tarjet' + indiceCard + '">Deshabilitar</label ></div ></div ></div ></div ></div ></form>';
                        cont++;
                    });
                    $("#tarjets").append(html);
                    for (var i = 0; i < data.cards.length; i++) {
                        //let checkBoxCheck = $("#tarjet" + i);
                        //if (data.cards[i].cardDisabled) {
                        //    checkBoxCheck.style = 'checked';
                        //}
                        document.getElementById("numberTarjet" + i).value = data.cards[i].cardNumber;
                    }
                }
                if (data.customs.length > 0) {
                    $("#Combo3").val(data.customs[1].customFieldNumericalData);
                    $("#0").val(data.customs[0].customFieldTextData);
                    $("#Combo4").val(data.customs[2].customFieldNumericalData);
                }

            } else {
                toastEror();
            }
        },
        error: function (data) {

        }
    });
}

function alertSuccess() {
    var dialog = bootbox.dialog({
        message: '<p class="text-center mb-0"><i class="fa fa-spin fa-cog"></i> Cargando, un momento por favor...</p>',
        centerVertical: true,
        closeButton: false
    });

    dialog.init(function () {
        setTimeout(function () {
            dialog.modal('hide');
        }, 3000);
    });
}

async function onChange() {
    let option = document.getElementById("Sites");
    let siteId = option.value;
    await getCustomFields(siteId);
}

async function fillControls() {
    document.getElementById('Sites').disabled = true;
    let sites = await getSite();

    if (sites && sites.length > 0) {
        SiteId = sites[0].siteID;
        /* await levelAccesGenerate(SiteId);*/
        a = document.querySelector("#Sites");

        for (var i = 0; i < sites.length; i++) {
            op = document.createElement("option");
            op.value = sites[i].siteId;
            op.text = sites[i].name;
            a.add(op);
        }
        document.getElementById('Sites').disabled = false;
    }
}

async function getSite() {
    let sites;

    await $.ajax({
        async: true,
        url: 'SecurityExpert/GetSiteId',
        data: { jsonobtj: JSON.stringify() },
        type: "POST",
        success: function (data) {
            if (data.length > 0) {
                sites = data;
            } else {
                toastEror();
            }
        },
        error: function (data) {

        }
    });
    return sites;
}

async function getCustomFields(siteId) {
    let fieldsId = [];
    let site = siteId;
    $.ajax({
        async: true,
        url: 'SecurityExpert/GetCustomFields',
        data: { jsonobtj: site },
        type: "POST",
        success: async function (data) {
            if (data.length > 0) {
                await levelAccesGenerate(site);
                $("#customFields").html("");
                var html = "";
                data.forEach(function (valor, indice, array) {
                    if (valor.fieldType == 7) {
                        html += '<div class="col-md-4 mb-3">'
                            + '<label class="form-label" for="Combo' + valor.customFieldId + '">' + valor.name + '</label>'
                            + '<select class="form-control" id="Combo' + valor.customFieldId + '" name="Combo' + valor.customFieldId + '">'
                            + '</select></div>';

                        fieldsId.push(valor.customFieldId);
                    } else if (valor.fieldType == 0) {
                        html += '<div class="col-md-4 mb-3">'
                            + '<label class="form-label" for="' + valor.customFieldId + '">' + valor.name + '</label>'
                            + '<input type="text" id="' + valor.customFieldId + '" class="form-control" placeholder="' + valor.name + '"></div>';
                    }

                });
                $("#customFields").append(html);
                fields = $("#customFields");
                customIds = fieldsId;
                fieldsId.forEach(async function (id) {
                    await getFieldList(id);
                });
                if (ide != 0 || ide != "undefined") {
                    document.getElementById("0").value = ide;
                }

            } else {
                toastEror();
            }
        },
        error: function (data) {

        }
    });
    return fieldsId;

}

async function getFieldList(id) {
    await $.ajax({
        async: true,
        url: 'SecurityExpert/GetListCustom',
        data: { jsonobtj: JSON.stringify(id) },
        type: "POST",
        success: function (dato) {
            if (dato.length > 0) {
                a = document.querySelector("#Combo" + id + "");
                for (var i = 0; i < dato.length; i++) {
                    op = document.createElement("option");
                    op.value = dato[i].actualValue;
                    op.text = dato[i].displayName;
                    a.add(op);
                }
                $("#Combo0").val("0");
                $("#Combo4").val("0");
                toastSucces("Customs Fields cargados con exito!");
            } else {
                toastEror();
            }
        },
        error: function (request) {
            toastEror();
        }
    });
}

async function getAllPeople() {
    await $.ajax({
        url: 'SecurityExpert/GetAllPeople',
        data: { jsonobtj: JSON.stringify() },
        type: "POST",
        success: function (data) {
            if (data.length > 0) {
                var select = document.getElementById("selectPeople");
                dataUser = data;
                for (var i = 0; i < data.length; i++) {
                    var option = document.createElement('option');
                    option.text = data[i].firstName + " " + data[i].lastName;
                    option.value = data[i].userId;
                    select.add(option);
                }
                toastSucces("Usuarios cargados con exito!");
            } else {
                toastEror();
            }
        },
        error: function (data) {

        }
    });
}

var controls = {
    leftArrow: '<i class="@(Settings.Theme.IconPrefix) fa-angle-left" style="font-size: 1.25rem"></i>',
    rightArrow: '<i class="@(Settings.Theme.IconPrefix) fa-angle-right" style="font-size: 1.25rem"></i>'
}

var runDatePicker = function (picker) {
    // range picker
    $('#' + picker).datepicker({
        todayHighlight: true,
        templates: controls
    });
}

function toastSucces(message) {
    Command: toastr["success"](message, "Exitoso")

    toastr.options = {
        "closeButton": true,
        "debug": false,
        "newestOnTop": false,
        "progressBar": true,
        "positionClass": "toast-top-right",
        "preventDuplicates": false,
        "showDuration": 3000,
        "hideDuration": 1000,
        "timeOut": 8000,
        "extendedTimeOut": 8000,
        "showEasing": "swing",
        "hideEasing": "linear",
        "showMethod": "fadeIn",
        "hideMethod": "fadeOut"
    }
}

function toastEror(message) {
    Command: toastr["error"]("Opss!!, algo salió mal," + message + "", "Error")

    toastr.options = {
        "closeButton": true,
        "debug": false,
        "newestOnTop": false,
        "progressBar": true,
        "positionClass": "toast-top-right",
        "preventDuplicates": false,
        "showDuration": 3000,
        "hideDuration": 1000,
        "timeOut": 3000,
        "extendedTimeOut": 3000,
        "showEasing": "swing",
        "hideEasing": "linear",
        "showMethod": "fadeIn",
        "hideMethod": "fadeOut"
    }
}
