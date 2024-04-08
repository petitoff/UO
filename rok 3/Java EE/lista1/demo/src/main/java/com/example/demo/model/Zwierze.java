package com.example.demo.model;

import jakarta.persistence.*;

@Entity
@Inheritance(strategy = InheritanceType.JOINED)
public class Zwierze {
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private Integer id;
    private String kontynent;
    private Integer ilosc_konczyn;

    public Integer getId() {
        return id;
    }

    public void setId(Integer id) {
        this.id = id;
    }

    public String getKontynent() {
        return kontynent;
    }

    public void setKontynent(String kontynent) {
        this.kontynent = kontynent;
    }

    public Integer getIlosc_konczyn() {
        return ilosc_konczyn;
    }

    public void setIlosc_konczyn(Integer ilosc_konczyn) {
        this.ilosc_konczyn = ilosc_konczyn;
    }
}
