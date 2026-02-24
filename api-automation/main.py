from environment_variables import endpoints
from dtos.user_dtos import *
from enums import UserRole
from api_client import *
from rich import print
from faker import Faker

if __name__ == '__main__':
    try:
        client: APIClient = APIClient()

        count: int = 7
        fake: Faker = Faker()
        bulk: CreateBulkUserDto = CreateBulkUserDto()
        unique_emails = [fake.unique.email() for _ in range(count)]
        for i in range(count):
            user: CreateUserDto = CreateUserDto(
                username=fake.user_name(),
                email=fake.email(),
                password=fake.password(length=8, lower_case=True, digits=True),
                role=fake.enum(UserRole).value
            )
            bulk.add(user)

        print('Inserting! Please Wait...')
        response = client.post(
            endpoint=CreateBulkUserDto.endpoint(),
            data=bulk.json
        )

        print(response.text)

    except Exception as e:
        print("It seems the backend server might be offline.", f"{e}", sep='\n\n')
