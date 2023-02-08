$(() => {
    $('.cart').on('click', (e) => {
        let curentItem = e.currentTarget;
    


        $.ajax({
            url: '/cart/add/1',
            method: 'post',
            success: (data) => { console.log(data) },
            error: (err) => { console.log(err) }
        });
    });


    $('.delete').on('click', (e) => {
        let curentItem = e.currentTarget;
    });

    $('.quantity-plus').on('click', (e) => {
        let curentItem = e.currentTarget;
        $.ajax({
            url: '/cart/increase/1',
            method: 'post',
            success: (data) => { console.log(data) },
            error: (err) => { console.log(err) }
        });

    });

    $('.quantity-minus').on('click', (e) => {
        let curentItem = e.currentTarget;
        $.ajax({
            url: '/cart/decrease/1',
            method: 'post',
            success: (data) => { console.log(data) },
            error: (err) => { console.log(err) }
        });

    });


    $('.sc-produc-remove').on('click', (e) => {
        let curentItem = e.currentTarget;

        $.ajax({
            url: '/cart/delete/1',
            method: 'post',
            success: (data) => { console.log(data) },
            error: (err) => { console.log(err) }
        });
    })
})