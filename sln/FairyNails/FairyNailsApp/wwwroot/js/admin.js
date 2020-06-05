let content = document.getElementById("content");
/** content call**/
async function getContent(sender) {
    let actions = {
        agenda: agendaAction,
        prestations: prestationsAction,
        clients: clientsAction
    }

    let actionId = sender.getAttribute("id")
    let action = actions[`${actionId}`]

    let response = await fetch(action, {
        method: 'POST'
    });
    let responseData = await response.text();
    if (response.ok) {
        content.innerHTML = responseData;
        datePickerSetup()
        AcceptRejectRendezVousListner()
        CancelRendezVousListner()
        if (actionId == "clients") {
            $('#clientsTable').DataTable(
                {
                    language: {
                        "emptyTable": "Aucun Clients",
                        "info": "Affiche _START_ à _END_ de _TOTAL_ clients",
                        "infoEmpty": "Affiche 0 à 0 des 0 évènements",
                        "infoFiltered": "(filtered from _MAX_ total entries)",
                        "infoPostFix": "",
                        "thousands": " ",
                        "lengthMenu": "Afficher _MENU_ clients",
                        "loadingRecords": "Chargement...",
                        "processing": "Chargement...",
                        "search": "Rechercher :",
                        "zeroRecords": "Pas de client trouvés pour cette recherche",
                        "paginate": {
                            "first": "Premier",
                            "last": "Dernier",
                            "next": "Suivant",
                            "previous": "Précédent"
                        },
                    },
                    buttons: [
                        {
                            text: 'Reload',
                            action: function (e, dt, node, config) {
                                dt.ajax.reload();
                            }
                        }
                    ]
                }
            );
        }
    }
    else {
        console.log('erreur');
    }
}

/** Datepicker JS **/
function datePickerSetup() {
    $('.datepicker').datepicker({
        language: "fr",
        todayBtn: true,
        todayHighlight: true,
        format: "dd/mm/yyyy",
        autoclose: true
    });
}

/** Accept / Reject listner **/
function AcceptRejectRendezVousListner() {
    let validationBtn = document.querySelectorAll(".validationBtn");
    validationBtn.forEach(element => element.addEventListener("click", validRejectRdv))
};

/** Cancel Rdv listner **/
function CancelRendezVousListner() {
    let validationBtn = document.querySelectorAll(".cancelBtn");
    validationBtn.forEach(element => element.addEventListener("click", cancelRdv))
};

/** GetRendezVous for day pick ajax request **/
async function getRendezVous(e) {

    let datechosen = document.getElementById("datechosen");
    let rendezvous = document.getElementById("rendezvous");
    let param = `date=${datechosen.value}`;

    let response = await fetch(dayRdvAction, {
        method: 'POST',
        headers: {
            "Content-Type": "application/x-www-form-urlencoded",
        },
        body: param,
    });
    let responseData = await response.text();
    if (response.ok) {
        rendezvous.innerHTML = responseData;
        CancelRendezVousListner()
    }
    else {
        console.log('erreur');
    }
}

//** Accept/reject rdv ajax request **/
async function validRejectRdv(e) {
    let command = this.dataset.command;
    let confirm = true;
    if (command === "reject") {
        confirm = await Swal.fire({
            title: 'Refuser',
            text: "Êtes vous sûr de vouloir refuser ce rendez-vous ?",
            icon: "warning",
            showCancelButton: true,
            confirmButtonText: 'Confirmer',
            cancelButtonText: 'Retour',
        })
    }
    if (confirm === true || confirm.value) {
        let rdv = this.dataset.rdv;
        let waitingrdv = document.getElementById("waitingrdv");
        let param = `idRdv=${rdv}&command=${command}`;

        let response = await fetch(acceptRejectAction, {
            method: 'POST',
            headers: {
                "Content-Type": "application/x-www-form-urlencoded",
            },
            body: param,
        });
        let responseData = await response.text();
        if (response.ok) {
            waitingrdv.innerHTML = responseData;
            AcceptRejectRendezVousListner()
        }
        else {
            console.log('erreur');
        }
    }
}

//** Cancel rdv ajax request **/
async function cancelRdv() {
    Swal.fire({
        title: 'Attention!',
        text: "Êtes vous sûr d'annuler ce rendez-vous ?",
        icon: "warning",
        showCancelButton: true,
        confirmButtonText: 'Confirmer',
        cancelButtonText: 'Retour',
    })
        .then(async (result) => {
            if (result.value) {
                let rdv = this.dataset.rdv;
                let date = this.dataset.date;
                let rendezvous = document.getElementById("rendezvous");
                let param = `idRdv=${rdv}&date=${date}`;

                let response = await fetch(cancelRdvAction, {
                    method: 'POST',
                    headers: {
                        "Content-Type": "application/x-www-form-urlencoded",
                    },
                    body: param,
                });
                let responseData = await response.text();
                if (response.ok) {
                    rendezvous.innerHTML = responseData;
                    CancelRendezVousListner()
                }
                else {
                    console.log('erreur');
                }
            }
        })
}
/** EditPrestation form function **/

async function editPrestationForm(sender) {
    let idPrestation = sender.dataset.prestation;
    let param = `idPrestation=${idPrestation}`

    let response = await fetch(editPrestationFormAction, {
        method: 'POST',
        headers: {
            "Content-Type": "application/x-www-form-urlencoded",
        },
        body: param,
    });
    let responseData = await response.text();
    if (response.ok) {
        content.innerHTML = responseData;
    }
    else {
        console.log('erreur');
    }
}

/** AddPrestation form function **/

async function addPrestationForm() {

    let response = await fetch('', {
        method: 'POST'
    });
    let responseData = await response.text();
    if (response.ok) {
        content.innerHTML = responseData;
    }
    else {
        console.log('erreur');
    }
}