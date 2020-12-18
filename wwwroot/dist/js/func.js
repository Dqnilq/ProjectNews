// Вход
function signin() {
    let form = document.signIn;
    let name = form.name.value;
    let password = form.password.value;
    let remember = form.remember.checked;

    if (name.length < 1 || password.length < 1){
        alert("Заполните все поля");
        return;
    }

    // TODO запомнить меня

    $.ajax({
        type: 'POST',
        url: '/authorization',
        headers: {
            'name': name,
            'password': password,
            'remember': remember,
            'new_user': 'false'
        },
        success: function(res, status, xhr) {
            let result = xhr.getResponseHeader("result")
            if (result === "ok")
                document.location.href = "Account"
            else
                alert("Неверный логин или пароль")
        }
    })
}


// Регистрация
function signup() {
    let form = document.signUp;
    let name = form.name.value;
    let password1 = form.password1.value;
    let password2 = form.password2.value;
    let username = form.realname.value;
    let phonenum = form.phone.value;

    let checkName = /^[a-zA-Zа-яёА-ЯЁ]{3,20}$/.test(name);
    let checkPassword = /^(?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{6,}$/.test(password1);

    if (name.length < 1 || password1.length < 1|| password2.length < 1) {
        alert("Заполните все поля");
        return;
    }
    if (!checkName) {
        alert('Логин должен сожержать минимум 3 символа и состоять только из букв!')
        return;
    }
    if (!checkPassword) {
        alert('Пароль слишком пройстой!' +
            '\nОн должен состоять минимум из 6 символов' +
            '\nи содержать минимум одну цифру, одну заглавную и одну строчную буквы.' +
            '\n(только латинские буквы');
        return;
    }
    if (password2 !== password1) {
        alert("Пароли не совпадают!")
        return;
    }

    $.ajax({
        type: 'POST',
        url: '/authorization',
        headers: {
            'name': name,
            'password': password1,
            'user_name' : username,
            'phone_num' : phonenum,
            'new_user': 'true'
        },
        success: function(res, status, xhr) {
            let result = xhr.getResponseHeader("result")
            if (result === "ok")
                document.location.href = "RegDone"
            else if (result === "error")
                alert("Произошла ошибка при регистрации. Проверьте введенные данные")
            else
                alert("Этот логин уже занят")
        }
    })
}
