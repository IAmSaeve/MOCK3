// Import
import axios, { } from "../../node_modules/axios/index";

// Variables
const meassurementsTable: HTMLTableElement = document.getElementById("meassurementsTable") as HTMLTableElement;
const getbtn: HTMLButtonElement = document.getElementById("getAll") as HTMLButtonElement;
const getOnebtn: HTMLButtonElement = document.getElementById("getA") as HTMLButtonElement;
const getIdInput: HTMLInputElement = document.getElementById("meassurementId") as HTMLInputElement;
const deletebtn: HTMLButtonElement = document.getElementById("removeM") as HTMLButtonElement;
const deleteID: HTMLInputElement = document.getElementById("rmId") as HTMLInputElement;

// URL to server
const uri: string = "https://easj-mock3.azurewebsites.net/api/Meassurement/";

// Event listeners
getbtn.addEventListener("click", ShowAllMeassurements);
getOnebtn.addEventListener("click", ShowAMeassurement);
deletebtn.addEventListener("click", DeleteMeassurement);

function ShowAllMeassurements() {
    axios.get<Imeassurement[]>(uri)
        .then((response) => {
            // Clears list on button press
            meassurementsTable.innerHTML = "";

            // Loop data in array and add to HTML table
            response.data.forEach((c: Imeassurement) => {
                const row = meassurementsTable.insertRow();

                const i = row.insertCell();
                const h = row.insertCell();
                const p = row.insertCell();
                const t = row.insertCell();
                const ts = row.insertCell();

                i.innerText = c.id.toString();
                h.innerText = c.humidity.toString();
                p.innerText = c.pressure.toString();
                t.innerText = c.temperature.toString();
                ts.innerText = c.timeStamp.toString();
            });
        }).catch((error) => {
            console.error(error);
        });
}

function ShowAMeassurement() {
    axios.get<Imeassurement>(uri + getIdInput.valueAsNumber)
        .then((response) => {
            // Clears list on button press
            meassurementsTable.innerHTML = "";

            // Loop data in array and add to HTML table
            const c: Imeassurement = response.data;
            const row = meassurementsTable.insertRow();

            const i = row.insertCell();
            const h = row.insertCell();
            const p = row.insertCell();
            const t = row.insertCell();
            const ts = row.insertCell();

            i.innerText = c.id.toString();
            h.innerText = c.humidity.toString();
            p.innerText = c.pressure.toString();
            t.innerText = c.temperature.toString();
            ts.innerText = c.timeStamp.toString();
        }).catch((error) => {
            console.error(error);
        });
}

function DeleteMeassurement() {
    axios.delete(uri + deleteID.valueAsNumber)
    .then(() => {
        ShowAllMeassurements();
    })
    .catch((e) => {
        console.error(e);
    });
}

// meassurement interface
interface Imeassurement {
    id: number;
    pressure: string;
    humidity: number;
    temperature: string;
    timeStamp: string;
}
