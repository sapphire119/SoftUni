function solve(priceWithVat, VATRatePercent) {
    //x + x * y = z
    //100 + (100 * 0.20) = 120;
    //x + (x * 20) = 120;
    //x + 0.2x = 120;
    //1.2x = 120;
    //x = 100;

    let lookedForPrice = 0;

    let vatRateDec = 1 + (Number(VATRatePercent) / 100);

    lookedForPrice = Number(priceWithVat) / vatRateDec;

    return lookedForPrice.toFixed(2);
}

console.log(solve(120.00,
    20.00));

console.log(solve(220, 10));