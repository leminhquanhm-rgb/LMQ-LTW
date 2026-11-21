// AssetHub - hiệu ứng giao diện cơ bản (nút "lên đầu trang")
$(function () {
    $(window).on('scroll', function () {
        $('.to-top').toggle($(this).scrollTop() > 200);
    });
    $('.to-top').on('click', function () {
        $('html, body').animate({ scrollTop: 0 }, 400);
    });
    $('.search-box input').on('focus', function () { $(this).select(); });
});



const URL_LOC_THEO_LOAI = '/Home/LocTheoLoai';

function locTheoLoai(maLoai) {
    $.get(URL_LOC_THEO_LOAI, { maLoai: maLoai }, function (html) {
        $('#khu-vuc-ts').html(html);
    });
}


function danhDauMenu(liHienTai) {
    $('.menu li').removeClass('active');
    liHienTai.addClass('active');
}

$(function () {
    $('.loai-link').on('click', function (e) {
        e.preventDefault();
        locTheoLoai($(this).data('maloai'));
        danhDauMenu($(this).closest('li'));
    });
});