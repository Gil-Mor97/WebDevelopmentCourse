import React from 'react';

const userOutput = ( props ) => {
    return (
        <div>
            <p>I'm {props.username}</p>
            <p>{props.children}</p>
        </div>
    )
};

export default userOutput;
