import React from 'react'
import { Link } from 'react-router-dom'
import { Layout, Menu } from 'antd'
import { MenuItem } from '@mui/material'
import { Col, Row } from 'antd'
const { Header } = Layout
const Navbar = () => {
  return (
    <Header>
      <div className="logo" />
      <Menu
        style={{ Width: '100%', display: 'block' }}
        theme="dark"
        mode="horizontal"
        defaultSelectedKeys={['1']}
      >
        <Row>
          <Col span={6}>
            <MenuItem>
              <Link to="/" className="nav--item">
                Home
              </Link>
            </MenuItem>
          </Col>
          <Col span={6}>
            <MenuItem>
              <Link to="/posts" className="nav--item">
                Student
              </Link>
            </MenuItem>
          </Col>
          <Col span={6}>
            <MenuItem>
              <Link to="/profile" className="nav--item">
                Profile
              </Link>
            </MenuItem>
          </Col>
          <Col span={6}>
            <MenuItem>
              <Link to="/login" className="nav--item">
                Login
              </Link>
            </MenuItem>
          </Col>
        </Row>
      </Menu>
    </Header>
  )
}

export default Navbar
