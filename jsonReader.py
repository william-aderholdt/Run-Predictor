import json

with open('weather.json', 'r') as f:
    data = json.load(f)

print(data)