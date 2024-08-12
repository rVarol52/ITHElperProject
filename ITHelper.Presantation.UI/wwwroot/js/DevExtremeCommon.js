function ShowDevNotify(type, message,time) {

    DevExpress.ui.notify(
        {
            message,
            width: '100%',
            position: {
                my: 'top center',
                at: 'top center',
                of: window,
                offset: '0 0'
            }
        },
        type,
        time
    );
}