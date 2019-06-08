import axios from "axios";

export default axios.create({
  baseURL: "http://localhost:62727/api",
  withCredentials: true
});
