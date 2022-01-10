let signIn = document.querySelector('#signin')
let signUp = document.querySelector('#signup')
let body = document.querySelector("body")

signIn.addEventListener('click', function(){
    body.className = 'sign-in-js'
})
signUp.addEventListener('click', function(){
    body.className = 'sign-up-js'
})
(function() {
    'use strict'

    // Fetch all the forms we want to apply custom Bootstrap validation styles to
    var forms = document.querySelectorAll('.needs-validation')

    // Loop over them and prevent submission
    Array.prototype.slice.call(forms)
        .forEach(function(form) {
            form.addEventListener('submit', function(event) {
                if (!form.checkValidity()) {
                    event.preventDefault()
                    event.stopPropagation()
                }

                form.classList.add('was-validated')
            }, false)
        })
})()