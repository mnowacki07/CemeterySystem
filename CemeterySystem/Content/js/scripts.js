jQuery.validator.addMethod(
    "priceRegex",
    function (value, element, regexp) {
        return this.optional(element) || new RegExp("^([0-9])+((\.){1}[0-9]{1,2}){0,1}$").test(value);
    },
    "Niepoprawna cena"
);