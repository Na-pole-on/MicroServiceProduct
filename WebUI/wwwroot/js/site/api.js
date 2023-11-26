async function getItems() {
    const response = await fetch("/home/getall", {
        method: "GET",
        headers: { "Accept": "application/json" }
    });

    if (response.ok === true) {
        const items = await response.json();
        const rows = document.querySelector(".item-list");

        items.forEach(item => rows.append(row(item)));
    }
}

async function deleteItem(id) {
    const response = await fetch("/home/delete/" + id, {
        method: "DELETE",
        headers: { "Accept": "application/json" },
    });

    if (response.ok === true) {
        updateList();
    }
}

async function updateItem(item) {
    const response = await fetch("/home/update", {
        method: "POST",
        headers: {
            "Accept": "application/json",
            "Content-Type": "application/json"
        },
        body: JSON.stringify({
            id: parseInt(item.id),
            name: item.name,
            description: item.description,
            price: parseFloat(item.price),
            createdDate: item.createdDate
        })
    });
}

getItems();