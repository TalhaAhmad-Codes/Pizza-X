# Using Python `requests` Library for HTTP Methods

This guide explains how to perform common HTTP operations using the
`requests` library in Python.

------------------------------------------------------------------------

## Installation

``` bash
pip install requests
```

------------------------------------------------------------------------

# 1. GET Request

Used to retrieve data from a server.

``` python
import requests

url = "https://api.example.com/pizzas"

response = requests.get(url)

print("Status Code:", response.status_code)
print("Response JSON:", response.json())
```

------------------------------------------------------------------------

# 2. POST Request

Used to send data to the server (create new resource).

``` python
import requests

url = "https://api.example.com/pizzas"

payload = {
    "name": "Pepperoni",
    "price": 1200,
    "description": "Loaded with spicy pepperoni and mozzarella cheese."
}

response = requests.post(url, json=payload)

print("Status Code:", response.status_code)
print("Response:", response.text)
```

------------------------------------------------------------------------

# 3. PUT Request

Used to completely update an existing resource.

``` python
import requests

url = "https://api.example.com/pizzas/1"

payload = {
    "name": "Updated Pepperoni",
    "price": 1300,
    "description": "Updated description."
}

response = requests.put(url, json=payload)

print("Status Code:", response.status_code)
print("Response:", response.text)
```

------------------------------------------------------------------------

# 4. PATCH Request

Used to partially update a resource.

``` python
import requests

url = "https://api.example.com/pizzas/1"

payload = {
    "price": 1400
}

response = requests.patch(url, json=payload)

print("Status Code:", response.status_code)
print("Response:", response.text)
```

------------------------------------------------------------------------

# 5. DELETE Request

Used to remove a resource.

``` python
import requests

url = "https://api.example.com/pizzas/1"

response = requests.delete(url)

print("Status Code:", response.status_code)
print("Response:", response.text)
```

------------------------------------------------------------------------

# Adding Headers (Example: Authorization)

``` python
headers = {
    "Authorization": "Bearer YOUR_JWT_TOKEN"
}

response = requests.get(url, headers=headers)
```

------------------------------------------------------------------------

# Handling Errors

``` python
if response.ok:
    print("Success")
else:
    print("Error:", response.status_code)
```

------------------------------------------------------------------------

# Best Practice: Reusable API Client Class

``` python
import requests

class APIClient:
    def __init__(self, base_url, token=None):
        self.base_url = base_url
        self.headers = {}
        if token:
            self.headers["Authorization"] = f"Bearer {token}"

    def get(self, endpoint):
        return requests.get(f"{self.base_url}/{endpoint}", headers=self.headers)

    def post(self, endpoint, data):
        return requests.post(f"{self.base_url}/{endpoint}", json=data, headers=self.headers)

    def put(self, endpoint, data):
        return requests.put(f"{self.base_url}/{endpoint}", json=data, headers=self.headers)

    def patch(self, endpoint, data):
        return requests.patch(f"{self.base_url}/{endpoint}", json=data, headers=self.headers)

    def delete(self, endpoint):
        return requests.delete(f"{self.base_url}/{endpoint}", headers=self.headers)


# Example usage:
client = APIClient("https://api.example.com")
response = client.get("pizzas")
print(response.json())
```
