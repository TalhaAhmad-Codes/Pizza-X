from environment_variables import server
import requests as req

class APIClient:
    def __init__(self, token: str | None = None):
        self.__token: str | None = token

    @property
    def headers(self) -> dict:
        return {
            "Authorization": f"Bearer {self.__token}"
        } if self.__token is not None else {}

    def get(self, endpoint: str) -> req.Response:
        return req.get(f"{server['api']}{endpoint}", headers=self.headers, verify=False)

    def post(self, endpoint: str, data: dict) -> req.Response:
        return req.post(f"{server['api']}{endpoint}", json=data, headers=self.headers, verify=False)

    def put(self, endpoint: str, data: dict) -> req.Response:
        return req.put(f"{server['api']}{endpoint}", json=data, headers=self.headers, verify=False)

    def patch(self, endpoint: str, data: dict) -> req.Response:
        return req.patch(f"{server['api']}{endpoint}", json=data, headers=self.headers, verify=False)

    def delete(self, endpoint: str) -> req.Response:
        return req.delete(f"{server['api']}{endpoint}", headers=self.headers, verify=False)
