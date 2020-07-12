function createTree(containerElement, folderData) {
    let container = $(containerElement);
    if (!folderData) {
        console.error("Attenzione: i dati della directory non sono definiti");
        return;
    }
    prepareIcons(folderData);
    container.jstree({
        'core': {
            'data': [
                {
                    text: folderData.FolderName,
                    children: folderData.children
                }
            ],
            "themes": {
                "dots" : false
            }
        },
        types: {
            "pdf": {
                "icon": "fas fa-file-pdf "
            },
            "image": {
                "icon": "fas fa-image"
            },
            "file": {
                "icon": "glyphicon glyphicon-file"
            }
        },
        plugins: ["search", "themes", "types"]
    });
    console.log(folderData)
}
function prepareIcons(folderData) {

}