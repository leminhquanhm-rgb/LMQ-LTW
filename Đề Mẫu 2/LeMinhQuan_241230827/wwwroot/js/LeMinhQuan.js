function napSachTheoTheLoai($link) {
    $.get($link.attr('href'), function (html) {
        $('#noi-dung').html(html);
        $('.menu li').removeClass('active');
        $link.parent().addClass('active');
    });
}

$(function () {
    $(document).on('click', '.menu-tl', function (e) {
        e.preventDefault();

        // đang ở trang không có #noi-dung (ví dụ trang Create) thì về trang chủ
        if ($('#noi-dung').length === 0) {
            window.location.href = '/';
            return;
        }
        napSachTheoTheLoai($(this));
    });
});