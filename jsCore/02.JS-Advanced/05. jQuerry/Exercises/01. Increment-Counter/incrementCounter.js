function increment(selector) {
    let $textArea =$('<textarea>').addClass("counter").val(0).attr('disabled', true);
    let $incrementBtn = $('<button>').addClass('btn').attr('id', 'incrementBtn').text('Increment');
    let $addBtn = $('<button>').addClass('btn').attr('id', 'addBtn').text('Add');
    let $ul = $('<ul>').addClass('results');


    $incrementBtn.click(addOne);
    $addBtn.click(addToList);

    function addOne() {
        debugger;
        $(".counter").val((_, value) => Number(value) + 1);
        debugger;
    }

    function addToList() {
        debugger;
        let currentValue = $('.counter').val();
        debugger;
        let $li = $('<li>').text(currentValue);
        debugger;
        $ul.append($li);
        debugger;
    }

    $(selector)
        .append($textArea)
        .append($incrementBtn)
        .append($addBtn)
        .append($ul);
}
