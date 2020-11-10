#include "inc/ConnectForm.hh"

ConnectForm::ConnectForm(QWidget *parent) : QMainWindow(parent), _ui(new Ui::ConnectForm())
{
    this->_ui->setupUi(this);
}

Ui::ConnectForm* ConnectForm::getUI() const
{
	return this->_ui;
}

void ConnectForm::addKeyboard(const std::string& name)
{
	this->_ui->inputComboBox->addItem(QString::fromStdString(name));
	this->_ui->outputComboBox->addItem(QString::fromStdString(name));
	this->_ui->inputComboBox->setCurrentIndex(this->_ui->inputComboBox->count() - 1);
	this->_ui->outputComboBox->setCurrentIndex(this->_ui->outputComboBox->count() - 1);
}