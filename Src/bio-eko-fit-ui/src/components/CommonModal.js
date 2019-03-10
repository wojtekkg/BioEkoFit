import React from 'react';
import './Modal.css'; 
import { Button } from 'react-bootstrap';
import Modal from 'react-bootstrap/Modal';

class CommonModal extends React.Component {
    render() {        
      return (
        <Modal
          onHide={this.props.onHide}
          show={this.props.show}
          size="lg"
          aria-labelledby="contained-modal-title-vcenter"
          centered
        >
          <Modal.Header closeButton>
            <Modal.Title id="contained-modal-title-vcenter">
                {this.props.header}
            </Modal.Title>
          </Modal.Header>
          <Modal.Body>
            {this.props.children}
          </Modal.Body>
          <Modal.Footer>
            <Button variant="success" onClick={this.props.onAccept}>{this.props.onAcceptLabel}</Button>
            <Button variant="danger" onClick={this.props.onHide}>{this.props.onHideLabel}</Button>
          </Modal.Footer>
        </Modal>
      );
    }
  }

export default CommonModal;
