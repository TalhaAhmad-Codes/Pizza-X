from rich import print
from enums import UserRole
from dtos.user_dtos import *
from api_client import *
from environment_variables import endpoints

if __name__ == '__main__':
    client: APIClient = APIClient()

    # dto: CreateUserDto = CreateUserDto(
    #     username='BilalAhmad',
    #     email='bilal@gamil.com',
    #     password='bilal123',
    #     role=2
    # )

    # response = client.post(
    #     endpoint=dto.endpoint,
    #     data=dto.json
    # )
    response = client.get(
        endpoint=endpoints['users']['normal']
    )

    # if response.status_code != 200:
    #     print(response.text)
    #     exit()
    #
    print(response.json())

    # This shows you EXACTLY what you sent to the server
    # print(f"Sent to {response.url}: {response.request.body}")
    # print(f"Status: {response.status_code}")
