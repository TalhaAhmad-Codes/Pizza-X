from environment_variables import endpoints

class CreateUserDto:
    def __init__(self, **kwargs):
        self.username: str = kwargs.get('username', '')
        self.email: str = kwargs.get('email', '')
        self.password: str = kwargs.get('password', '')
        self.role: int = kwargs.get('role', 0)

    @staticmethod
    def endpoint() -> str:
        return endpoints['users']['normal']

    @property
    def json(self) -> dict:
        return {
            'username': self.username,
            'password': self.password,
            'email': self.email,
            'role': self.role
        }

class CreateBulkUserDto:
    def __init__(self):
        self.items: list[CreateUserDto] = []

    def add(self, create_user_dto: CreateUserDto) -> None:
        self.items.append(create_user_dto)

    @staticmethod
    def endpoint() -> str:
        return endpoints['users']['bulk']

    @property
    def json(self) -> dict:
        return {
            'items': [
                item.json for item in self.items
            ]
        }
