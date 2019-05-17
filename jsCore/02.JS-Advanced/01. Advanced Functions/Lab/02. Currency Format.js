function getDollarFormatter(formatter) {
    return (value) => formatter(",", "$", true, value);
}