server: dict = {
    'api' : 'http://localhost:5136/api/'
}

endpoints: dict = {
    'users': {
        'normal': 'Users',
        'patch': {
            'username': 'Users/update/username',
            'email': 'Users/update/email',
            'password': 'Users/update/password',
            'profile-pic': 'Users/update/profile-pic'
        },
        'bulk': 'Users/bulk'
    }
}
