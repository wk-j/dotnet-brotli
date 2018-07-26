import React from "react";
import { render } from "react-dom";
import "semantic-ui-css/semantic.min.css"
import "./style.css"

class App extends React.Component {
    render() {
        return (
            <div className="ui button">Hello</div>
        )
    }
}

var el = document.getElementById("root")

render(<App />, el);