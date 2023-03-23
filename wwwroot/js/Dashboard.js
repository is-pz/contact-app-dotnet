

let formDeleteContact = document.querySelector("#formDeleteContact")

if (formDeleteContact) {

    formDeleteContact.addEventListener("submit", (e) => {
        e.preventDefault();

        Swal.fire({
            title: 'Are you sure to delete?',
            showCancelButton: true,
            confirmButtonText: 'Delete',
            cancelButtonText: 'Cancel',
            confirmButtonColor: "#dc3545",
            icon: 'warning',
        }).then((result) => {
            if (result.isConfirmed) {
                formDeleteContact.submit()
            } 
        })

    })

}
