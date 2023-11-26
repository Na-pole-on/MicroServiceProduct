function row(item) {
    const col = document.createElement("div");
    col.className = "col album-col";

    const card = document.createElement("div");
    card.className = "card shadow-sm";

    const svg = document.createElement("svg");
    svg.className = "bd-placeholder-img card-img-top";
    svg.style.width = "100%";
    svg.style.height = "225px";
    svg.style.background = "#55595c";

    const rect = document.createElement("rect");
    rect.style.width = "100%";
    rect.style.height = "100%";
    svg.append(rect);

    const text = document.createElement("text");
    text.style.position = "relative";
    text.style.top = "50%";
    text.style.left = "25%";
    text.style.color = "#eceeef";
    text.append(item.name);
    svg.append(text);

    card.append(svg);

    const card_body = document.createElement("div");
    card_body.className = "card-body";

    const items_row = document.createElement("div");
    items_row.className = "items-row";

    const p = document.createElement("p");
    p.className = "party-text";
    p.append(item.description);
    items_row.append(p);

    card_body.append(items_row);

    const d_flex = document.createElement("div");
    d_flex.className = "d-flex justify-content-between align-items-center";

    const btn_group = document.createElement("div");
    btn_group.className = "btn-group";

    const btn_upd = document.createElement("a");
    btn_upd.className = "btn btn-sm btn-outline-secondary";
    btn_upd.setAttribute("href", "/Home/Update/" + item.id);
    btn_upd.innerText = "Update";
    btn_group.append(btn_upd);

    const btn_del = document.createElement("button");
    btn_del.className = "btn btn-sm btn-outline-secondary";
    btn_del.addEventListener("click", async () => await deleteItem(item.id));
    btn_del.innerText = "Delete";
    btn_group.append(btn_del);

    const small = document.createElement("small");
    small.className = "text-body-secondary";
    small.append("$" + item.price);
    small.setAttribute("id", item.id);
    d_flex.append(btn_group);
    d_flex.append(small);

    card_body.append(d_flex);

    card.append(card_body);

    col.append(card);

    return col;
}

function deleteAll() {
    document.querySelector(".item-list").innerHTML = "";
}

function updateList() {
    deleteAll();
    getItems();
}