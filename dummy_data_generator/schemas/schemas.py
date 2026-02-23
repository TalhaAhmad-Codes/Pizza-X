from schemas.base.attribute import *

schemas: dict[str, list[Attribute]] = {
    'users' : [
        Attribute(
            name='username',
            datatype=DataType(
                type=Type.USER_NAME
            )
        ),
        Attribute(
            name='password',
            datatype=DataType(
                type=Type.PASSWORD
            )
        ),
        Attribute(
            name='email',
            datatype=DataType(
                type=Type.EMAIL
            )
        ),
        Attribute(
            name='role',
            datatype=DataType(
                type=Type.LIST,
                list_type=Type.INT
            )
        )
    ]
}
