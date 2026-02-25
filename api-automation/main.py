from dtos.user_dtos import *
from enums import UserRole
from api_client import *
from rich import print
from faker import Faker
from time import time

if __name__ == '__main__':
    try:
        client: APIClient = APIClient()

        count: int = 5000
        fake: Faker = Faker()
        bulk: CreateBulkUserDto = CreateBulkUserDto()
        unique_emails = [fake.unique.email() for _ in range(count)]
        for i in range(count):
            user: CreateUserDto = CreateUserDto(
                username=fake.user_name(),
                email=unique_emails[i],
                password="password12",
                role=fake.enum(UserRole).value
            )
            bulk.add(user)

        print('Inserting! Please Wait...')
        start = time()
        response = client.post(
            endpoint=CreateBulkUserDto.endpoint(),
            data=bulk.json
        )
        end = time()

        print("Time Taken:", f"{(end - start):.2} s", sep='\t')
        print(response.text)

    except Exception as e:
        print("It seems the backend server might be offline.", f"{e}", sep='\n\n')

"""
10:     1.7 s
20:     3.4 s
50:     8.3 s
100:    16.0 s
200:    33.0 s
500:    83.0 s
1000:   170.0 s
2000:   330.0 s
5000:   820.0 s
"""
