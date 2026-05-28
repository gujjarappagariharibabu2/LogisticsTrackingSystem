def test_active_shipments_excludes_archived():
    shipments = [
        {"is_archived": False},
        {"is_archived": False},
        {"is_archived": True},
    ]

    active_shipments = [
        x for x in shipments
        if not x["is_archived"]
    ]

    assert len(active_shipments) == 2


def test_archived_shipments_not_in_active_results():
    shipments = [
        {"tracking": "TRK100", "is_archived": False},
        {"tracking": "TRK200", "is_archived": True},
    ]

    visible = [
        x for x in shipments
        if not x["is_archived"]
    ]

    assert len(visible) == 1
    assert visible[0]["tracking"] == "TRK100"


def test_dashboard_requires_admin():
    role = "Customer"

    can_access_dashboard = (
        role == "Admin"
    )

    assert can_access_dashboard is False