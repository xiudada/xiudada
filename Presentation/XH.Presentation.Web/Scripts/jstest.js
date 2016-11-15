var func = function () {
    console.log(2);
}

func = func.before(function () {
    console.log(1);
}).after(function () {
    console.log(3);
});

func();