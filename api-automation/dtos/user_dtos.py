class CreateUserDto:
    def __init__(self, **kwargs):
        self.__username: str = kwargs.get('username', '')
        self.__email: str = kwargs.get('email', '')
        self.__password: str = kwargs.get('password', '')
        self.__role: int = kwargs.get('role', 0)

    @property
    def endpoint(self) -> str:
        return 'Users'

    @property
    def json(self) -> dict:
        return {
            'username': self.__username,
            'password': self.__password,
            'email': self.__email,
            'role': self.__role
        }
