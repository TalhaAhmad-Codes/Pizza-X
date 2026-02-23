from environment_variables import server
import requests

url = server['api'] + 'Users'

"""
[GET]

response = requests.get(url, verify=False)  # verify=False for local HTTPS

if response.status_code == 200:
    data = response.json()
    print(data)
else:
    print("Error:", response.status_code)
"""

"""

[POST]

response = requests.post(url, json={
"username": "TalhaAhmad1",
  "password": "talha987",
  "email": "talha.ahmad.tech@gmail.com",
  "role": 2
}, verify=False)

print(response.status_code, response.text, sep='\n')
"""

"""
(EXAMPLE)

import requests

class PizzaXClient:
    def __init__(self, base_url, token=None):
        self.base_url = base_url
        self.headers = {}
        if token:
            self.headers["Authorization"] = f"Bearer {token}"

    def get_pizzas(self):
        return requests.get(f"{self.base_url}/api/pizzas", headers=self.headers).json()

    def create_pizza(self, data):
        return requests.post(
            f"{self.base_url}/api/pizzas",
            json=data,
            headers=self.headers
        ).json()


client = PizzaXClient("https://localhost:5001")
print(client.get_pizzas())

"""
