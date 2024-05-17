from vvspy import get_departures


def get_departure_time(station_id, line):
    deps = get_departures(station_id, limit=50)
    dep_array = []
    for dep in deps:
        if dep.serving_line.symbol == line:
            dep_array.append(str(dep.real_datetime.time()))
    return dep_array


def get_delay(station_id, line):
    deps = get_departures(station_id, limit=50)
    del_array = []
    for dep in deps:
        if dep.serving_line.symbol == line:
            del_array.append(str(dep.delay))
    return del_array


def get_departure(station_id, line):
    deps = get_departures(station_id, limit=50)
    dir_array = []
    for dep in deps:
        if dep.serving_line.symbol == line:
            dir_array.append(str(dep))
    return dir_array

def get_departure_all(station_id):
    deps = get_departures(station_id, limit=30)
    dir_array = []
    for dep in deps:
        dir_array.append(str(dep))
    return dir_array

def get_delay_all(station_id):
    deps = get_departures(station_id, limit=30)
    del_array = []
    for dep in deps:
        del_array.append(str(dep.delay))
    return del_array


#print(get_departure("17803", "914"))
